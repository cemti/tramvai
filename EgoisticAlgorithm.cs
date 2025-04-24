namespace Tramvai;

public class EgoisticAlgorithm : IEthicalAlgorithm
{
    public string Decide(Scenario scenario, out string reasoning)
    {
        int childrenA = scenario.LinieA.Count(p => p.Varsta == Age.Copil);
        int childrenB = scenario.LinieB.Count(p => p.Varsta == Age.Copil);

        reasoning = Scenario.GetReasoning("Nr. de copii", childrenA, childrenB);

        return childrenA < childrenB ? "A" : "B";
    }
}
