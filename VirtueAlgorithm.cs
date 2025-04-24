namespace Tramvai;

public class VirtueAlgorithm : IEthicalAlgorithm
{
    public string Decide(Scenario scenario, out string reasoning)
    {
        int adultsA = scenario.LinieA.Count(p => p.Varsta == Age.Adult);
        int adultsB = scenario.LinieB.Count(p => p.Varsta == Age.Adult);

        reasoning = Scenario.GetReasoning("Nr. de adulți", adultsA, adultsB);

        return adultsA < adultsB ? "A" : "B";
    }
}
