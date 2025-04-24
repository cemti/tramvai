using System.Windows.Forms.DataVisualization.Charting;

namespace Tramvai;

public partial class Form1
{
    private static string AsPercentage(double number) => $"{number * 100:F2}%";

    private Dictionary<Person, double> survivalRates = [];
    
    private static Chart GetPieChart(string title, IEnumerable<KeyValuePair<string, int>> data)
    {
        Chart chart = new();
        chart.ChartAreas.Add("ChartArea");
        chart.Legends.Add("Legend");
        chart.Titles.Add(title);

        Series series = new()
        {
            XValueMember = "Key",
            YValueMembers = "Value",
            ChartType = SeriesChartType.Pie,
            IsValueShownAsLabel = true,
            Label = "#VALX (#VALY)\n#PERCENT"
        };

        chart.Series.Add(series);

        chart.DataSource = data.ToArray();
        chart.DataBind();

        return chart;
    }

    private static Chart GetSacrificeChart(string subiect, int saved, int sacrificed)
        => GetPieChart($"Sacrificări pentru {subiect}",
                       new[]
                       {
                           KeyValuePair.Create("Salvați", saved),
                           new("Sacrificați", sacrificed)
                       }.Where(x => x.Value > 0));

    private void PopulateStatisticsByAnswer()
    {
        Chart chart;

        chart = GetPieChart("Răspunsuri după utilizator",
                            from answer in answers
                            where answer.RaspunsUtilizator != ""
                            group answer by answer.RaspunsUtilizator into g
                            select KeyValuePair.Create(g.Key, g.Count()));

        trackStatisticsPanel.Controls.Add(chart);

        chart = GetPieChart("Răspunsuri după LLM",
                            from answer in answers
                            where answer.RaspunsLlm != ""
                            group answer by answer.RaspunsLlm into g
                            select KeyValuePair.Create(g.Key, g.Count()));

        trackStatisticsPanel.Controls.Add(chart);

        foreach (var algorithm in Algorithms)
        {
            var query = from answer in answers
                        where answer.TipAlgo == algorithm && answer.RaspunsAlgo != ""
                        group answer by answer.RaspunsAlgo into g
                        select KeyValuePair.Create(g.Key, g.Count());

            if (!query.Any())
            {
                continue;
            }

            chart = GetPieChart($"Răspunsuri după algoritmul {algorithm}", query);
            trackStatisticsPanel.Controls.Add(chart);
        }
    }

    private (int Saved, int Sacrificed) GetStatisticsBySelector(string actor, Func<Person, bool> selector)
    {
        string GetTrack(Answer answer)
            => actor switch
            {
                "Utilizator" => answer.RaspunsUtilizator,
                "LLM" => answer.RaspunsLlm,
                _ => answer.RaspunsAlgo
            };

        bool IsRequiredAnswer(Answer answer) => actor is "Utilizator" or "LLM" || answer.TipAlgo == actor;

        string GetOppositeTrack(string track) => track == "A" ? "B" : "A";

        List<Person> GetPersonsByTrack(Answer answer, string track)
            => track == "A" ? answer.Scenariu.LinieA : answer.Scenariu.LinieB;

        int GetPersonCount(Answer answer, string track) => GetPersonsByTrack(answer, track).Count(selector);

        var query = from answer in answers
                    where IsRequiredAnswer(answer)
                    let track = GetTrack(answer)
                    where track != ""
                    let oppositeTrack = GetOppositeTrack(track)
                    let tuple = (Saved: GetPersonCount(answer, oppositeTrack),
                                 Sacrificed: GetPersonCount(answer, track))
                    where tuple is not (0, 0)
                    select tuple;

        if (!query.Any())
        {
            return (0, 0);
        }

        return query.Aggregate((a, b) => (a.Saved + b.Saved, a.Sacrificed + b.Sacrificed));
    }

    private IEnumerable<(Person Person, int Saved, int Sacrificed)> GetStatisticsBySacrifices(string actor)
        => from race in Enum.GetValues<Race>()
           from gender in Enum.GetValues<Gender>()
           from age in Enum.GetValues<Age>()
           let person = new Person(race, gender, age)
           let statistics = GetStatisticsBySelector(actor, x => x.Equals(person))
           where statistics is not (0, 0)
           select (person, statistics.Saved, statistics.Sacrificed);

    private void PopulateStatisticsBySacrifices()
    {
        if (sacrificesComboBox.SelectedItem is not string actor)
        {
            return;
        }

        int totalSaved = 0, totalSacrificed = 0;

        foreach (var (person, salvati, sacrificati) in GetStatisticsBySacrifices(actor))
        {
            sacrificeStatisticsPanel.Controls.Add(GetSacrificeChart(person.ToString(), salvati, sacrificati));
            totalSaved += salvati;
            totalSacrificed += sacrificati;
        }

        sacrificeStatisticsPanel.Controls.Add(GetSacrificeChart("toți", totalSaved, totalSacrificed));
    }

    private void PopulateStatisticsCategoricallyBySacrifices()
    {
        if (sacrificesComboBox.SelectedItem is not string actor)
        {
            return;
        }

        var enumQuery = Enum.GetValues<Race>().Cast<Enum>()
                        .Concat(Enum.GetValues<Gender>().Cast<Enum>())
                        .Concat(Enum.GetValues<Age>().Cast<Enum>());

        var query = from enumeration in enumQuery
                    let statistics = GetStatisticsBySelector(actor, x => enumeration switch
                    {
                        Race race => x.Rasa == race,
                        Gender gender => x.Gen == gender,
                        Age age => x.Varsta == age,
                        _ => throw new InvalidOperationException()
                    })
                    where statistics is not (0, 0)
                    select (enumeration, statistics.Saved, statistics.Sacrificed);

        foreach (var (enumeration, saved, sacrificed) in query)
        {
            var chart = GetPieChart($"Sacrificări pentru {enumeration}",
                new[] {
                    KeyValuePair.Create("Salvați", saved),
                    new("Sacrificați", sacrificed)
                }.Where(x => x.Value > 0));

            categoricSacrificeStatisticsPanel.Controls.Add(chart);
        }
    }

    private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControl1.SelectedIndex == 0 || tabControl1.SelectedTab is not { Controls: [FlowLayoutPanel panel] })
        {
            return;
        }

        foreach (var disposable in panel.Controls.OfType<IDisposable>())
        {
            disposable.Dispose();
        }

        panel.Controls.Clear();

        switch (tabControl1.SelectedIndex)
        {
            case 1:
                PopulateStatisticsByAnswer();
                break;

            case 2:
                PopulateStatisticsBySacrifices();
                break;

            case 3:
                PopulateStatisticsCategoricallyBySacrifices();
                break;
        }
    }

    private void CalculeazaRateDeSupraviețuireToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Dictionary<Person, (int Saved, int Sacrificed)> fractions = [];
        
        foreach (var actor in Actors)
        {
            foreach (var (person, sacrificed, sacrificati) in GetStatisticsBySacrifices(actor))
            {
                if (fractions.TryGetValue(person, out var s))
                {
                    fractions[person] = (s.Saved + sacrificed, s.Sacrificed + sacrificati);
                }
                else
                {
                    fractions.Add(person, (sacrificed, sacrificati));
                }
            }
        }

        survivalRates = (from fraction in fractions
                         let total = fraction.Value.Saved + fraction.Value.Sacrificed
                         where total > 0
                         select (fraction.Key, (double)fraction.Value.Saved / total))
                        .ToDictionary();

        var text = string.Join(Environment.NewLine, from rate in survivalRates
                                                    orderby rate.Value descending
                                                    select $"{AsPercentage(rate.Value)} - {rate.Key}");

        if (sender is ToolStripMenuItem)
        {
            MessageBox.Show(text, "Calcularea ratelor de supraviețuire", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
