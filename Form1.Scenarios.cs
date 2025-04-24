using System.Text.Json;
using System.Text.RegularExpressions;

namespace Tramvai;

public partial class Form1
{
    private static readonly JsonSerializerOptions OutputJsonOptions = new() { WriteIndented = true };

    private int countdown = 10, totalTime;
    private Scenario? currentScenario;

    private Task StartScenario(Scenario scenario)
    {
        var l1 = string.Concat(scenario.LinieA.Select(x => x.Emoji));
        var l2 = string.Concat(scenario.LinieB.Select(x => x.Emoji));
        return webView21.ExecuteScriptAsync(@$"start('{l1}', '{l2}', {totalTime})");
    }

    private Task StopScenario(string cale) => webView21.ExecuteScriptAsync($"makeDecision('{cale}')");

    private void GenerateScenario()
    {
        currentScenario = ScenarioGenerator.GenerateScenario();

        var l1 = currentScenario.LinieA.Select(x => survivalRates.TryGetValue(x, out var rate) ? rate : .5);
        var l2 = currentScenario.LinieB.Select(x => survivalRates.TryGetValue(x, out var rate) ? rate : .5);

        decisionTextBox.Text = $@"Ratele de supraviețuire:
Linia A: {{{string.Join(", ", l1.Select(AsPercentage))}}} => {AsPercentage(l1.Average())}
Linia B: {{{string.Join(", ", l2.Select(AsPercentage))}}} => {AsPercentage(l2.Average())}
";
    }

    private void BtnGenereaza_Click(object sender, EventArgs e)
    {
        generateButton.Enabled = generateManyButton.Enabled = false;
        optionAButton.Enabled = optionBButton.Enabled = true;

        GenerateScenario();
        StartCountdown();
        StartScenario(currentScenario!);
    }

    private async void BtnGenereazaMulte_Click(object sender, EventArgs e)
    {
        int scenarioCount = (int)scenarioCountBox.Value;

        generateManyButton.UseWaitCursor = true;
        Random rnd = new();

        for (int i = 0; i < scenarioCount; ++i)
        {
            generateButton.Enabled = generateManyButton.Enabled = false;
            algorithmComboBox.SelectedIndex = rnd.Next(algorithmComboBox.Items.Count);

            GenerateScenario();
            await StartScenario(currentScenario!);
            await ProcessDecision("");
        }

        generateManyButton.Enabled = true;
        generateManyButton.UseWaitCursor = false;
    }

    private void StartCountdown()
    {
        if (!int.TryParse(timeInputBox.Text, out totalTime))
        {
            totalTime = 10;
        }

        countdown = totalTime;
        timerLabel.Text = $"Timp rămas: {countdown}";
        progressBar.Maximum = totalTime;
        progressBar.Value = totalTime;

        decisionTimer.Start();
    }

    private void DecisionTimer_Tick(object? sender, EventArgs e)
    {
        --countdown;
        timerLabel.Text = $"Timp rămas: {countdown}";
        progressBar.Value = Math.Max(0, countdown);

        if (countdown <= 0)
        {
            decisionTimer.Stop();
            _ = ProcessDecision("B");
        }
    }

    private void BtnOptiuneaA_Click(object sender, EventArgs e)
    {
        decisionTimer.Stop();
        _ = ProcessDecision("A");
    }

    private void BtnOptiuneaB_Click(object sender, EventArgs e)
    {
        decisionTimer.Stop();
        _ = ProcessDecision("B");
    }

    private async Task ProcessDecision(string userDecision)
    {
        try
        {
            if (currentAlgorithm is null || currentScenario is null)
            {
                return;
            }

            decisionTextBox.UseWaitCursor = true;

            await StopScenario(userDecision);

            decisionTextBox.AppendText($"Utilizatorul a ales: {userDecision}");

            string decisionAlg = currentAlgorithm.Decide(currentScenario, out var reasoningAlg);

            decisionTextBox.AppendText(@$"
Algoritmul a ales: {decisionAlg}
* Cu justificare: {reasoningAlg}");

            string decisionLlm = "", reasoningLlm = "";

            if (!deactivateLLMToolStripMenuItem.Checked)
            {
                try
                {
                    var raspunsLLM = await GenerateLLMResponseAsync(GeneratePrompt(currentScenario));

                    if (PromptRegex().Match(raspunsLLM) is { Groups: [_, { Value: var a }, { Value: var b }] })
                    {
                        decisionLlm = a;
                        reasoningLlm = b;
                    }
                }
                catch
                {
                }
            }

            decisionTextBox.AppendText(@$"
LLM a ales: {decisionLlm}
* Cu justificare: {reasoningLlm}");

            decisionTextBox.UseWaitCursor = false;

            answers.Add(new(currentScenario, userDecision, decisionLlm, reasoningLlm, $"{algorithmComboBox.SelectedItem}", decisionAlg, reasoningAlg));
            ShowScenarioCount();

            using var file = File.Open(FileName, FileMode.Create, FileAccess.Write);
            JsonSerializer.Serialize(file, answers, OutputJsonOptions);
        }
        finally
        {
            generateButton.Enabled = generateManyButton.Enabled = true;
            optionAButton.Enabled = optionBButton.Enabled = false;
        }
    }

    [GeneratedRegex(@"Opțiune:\s*(.+?)\r?\s*\nMotiv:\s*(.+)")]
    private static partial Regex PromptRegex();
}
