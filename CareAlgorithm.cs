namespace Tramvai;

public class CareAlgorithm : IEthicalAlgorithm
{
    public string Decide(Scenario scenario, out string reasoning)
    {
        int vulnerableA = scenario.LinieA.Count(p => p.Varsta != Age.Adult);
        int vulnerableB = scenario.LinieB.Count(p => p.Varsta != Age.Adult);

        reasoning = Scenario.GetReasoning("Nr. de copii și bătrâni", vulnerableA, vulnerableB);

        return vulnerableA < vulnerableB ? "A" : "B";
    }
}
