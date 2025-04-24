namespace Tramvai;

public class HybridAlgorithm(IEthicalAlgorithm[] algorithms, double[] weights) : IEthicalAlgorithm
{
    private readonly IEthicalAlgorithm[] algorithms = algorithms;
    private readonly double[] weights = weights;

    public string Decide(Scenario scenario, out string reasoning)
    {
        double scoreA = 0, scoreB = 0;
        reasoning = "";

        for (int i = 0; i < algorithms.Length; i++)
        {
            string decision = algorithms[i].Decide(scenario, out var partReasoning);
            reasoning += $"{partReasoning}{Environment.NewLine}";

            if (decision == "A")
            {
                scoreA += weights[i];
            }
            else
            {
                scoreB += weights[i];
            }
        }

        reasoning += Scenario.GetReasoning("Pondere totală", scoreA, scoreB);
        return scoreA >= scoreB ? "A" : "B";
    }
}
