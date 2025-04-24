using System.Text.Json;

namespace Tramvai;

public partial class Form1 : Form
{
    private static readonly string[] Algorithms = ["Utilitarist", "Deontologic", "Egoist", "Relativist", "Virtute", "Grija", "Contractualist", "Hibrid"],
                                     Actors = ["Utilizator", "LLM", .. Algorithms];

    private const string FileName = "scenarii.json";

    private readonly Dictionary<string, TrackBar> sliders = [];
    private readonly List<Answer> answers = [];

    private IEthicalAlgorithm currentAlgorithm = null!;

    private void ShowScenarioCount() => statusLabel.Text = $"Scenarii generate: {answers.Count}";

    public Form1()
    {
        InitializeComponent();

        sacrificesComboBox.SelectedIndexChanged += TabControl1_SelectedIndexChanged!;

        webView21.Source = new(Path.GetFullPath("index.html"));

        algorithmComboBox.DataSource = Algorithms;

        sacrificesComboBox.ComboBox.DataSource = Actors;
        sacrificesComboBox.ComboBox.BindingContext = new();

        for (int i = 0; i < Algorithms.Length - 1; ++i)
        {
            const int verticalSpacing = 50;

            Label lbl = new()
            {
                Text = Algorithms[i],
                Location = new Point(0, i * verticalSpacing + 10),
                Width = 100,
                Height = 20
            };

            TrackBar trk = new()
            {
                Minimum = 0,
                Value = 5,
                Width = 150,
                Location = new Point(95, i * verticalSpacing + 5)
            };

            sliders[Algorithms[i]] = trk;
            hybridWeightsPanel.Controls.Add(lbl);
            hybridWeightsPanel.Controls.Add(trk);
        }

        using var file = File.Open(FileName, FileMode.OpenOrCreate, FileAccess.Read);

        try
        {
            answers = JsonSerializer.Deserialize<List<Answer>>(file) ?? [];
        }
        catch
        {
        }

        ShowScenarioCount();

        if (answers.Count > 0)
        {
            CalculeazaRateDeSupraviețuireToolStripMenuItem_Click(this, EventArgs.Empty);
        }
    }

    private void CurataToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Confirmați acest lucru?", "Eliminarea scenariilor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            answers.Clear();
            File.WriteAllText(FileName, "[]");
        }
    }
}
