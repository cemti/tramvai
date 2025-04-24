namespace Tramvai;

public class UtilitarianAlgorithm : IEthicalAlgorithm
{
    public string Decide(Scenario scenario, out string reasoning)
    {
        int scoreA = scenario.LinieA.Count;
        int scoreB = scenario.LinieB.Count;

        reasoning = Scenario.GetReasoning("Nr. de persoane", scoreA, scoreB);

        return scoreA < scoreB ? "A" : "B";
    }
}
