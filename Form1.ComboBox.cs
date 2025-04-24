namespace Tramvai;

public partial class Form1
{
    private IEnumerable<double> GetWeightsFromUI()
    {
        double sum = sliders.Values.Sum(s => s.Value);

        return sum == 0
               ? Enumerable.Repeat(0.0, sliders.Count)
               : sliders.Values.Select(x => x.Value / sum);
    }

    private void ComboAlgoritmSelectat_SelectedIndexChanged(object? sender, EventArgs e)
    {
        string selection = algorithmComboBox.SelectedItem?.ToString() ?? "";

        currentAlgorithm = selection switch
        {
            "Deontologic" => new DeontologicalAlgorithm(),
            "Egoist" => new EgoisticAlgorithm(),
            "Relativist" => new RelativisticAlgorithm(),
            "Virtute" => new VirtueAlgorithm(),
            "Grija" => new CareAlgorithm(),
            "Contractualist" => new ContractualistAlgorithm(),
            "Hibrid" => new HybridAlgorithm(
                [
                    new UtilitarianAlgorithm(),
                    new DeontologicalAlgorithm(),
                    new EgoisticAlgorithm(),
                    new RelativisticAlgorithm(),
                    new VirtueAlgorithm(),
                    new CareAlgorithm(),
                    new ContractualistAlgorithm()
                ],
                [.. GetWeightsFromUI()]
            ),
            _ => new UtilitarianAlgorithm()
        };

        hybridWeightsPanel.Visible = currentAlgorithm is HybridAlgorithm;
    }
}
