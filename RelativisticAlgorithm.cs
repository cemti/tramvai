namespace Tramvai;

public class RelativisticAlgorithm : IEthicalAlgorithm
{
    public string Decide(Scenario scenario, out string reasoning)
    {
        int diversityA = scenario.LinieA.Select(p => p.Rasa).Distinct().Count();
        int diversityB = scenario.LinieB.Select(p => p.Rasa).Distinct().Count();

        reasoning = Scenario.GetReasoning("Diversitate dupa rasă", diversityA, diversityB);

        return diversityA < diversityB ? "A" : "B";
    }
}
