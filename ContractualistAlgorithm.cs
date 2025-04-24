namespace Tramvai;

public class ContractualistAlgorithm : IEthicalAlgorithm
{
    private static double GetDistribution(List<Person> track)
    {
        double total = track.Count;

        var distributions = from person in track
                            group person by person into p
                            select p.Count() / total;

        return distributions.Sum(d => d * Math.Abs(Math.Log(d)));
    }

    public string Decide(Scenario scenario, out string reasoning)
    {
        double distributionA = GetDistribution(scenario.LinieA);
        double distributionB = GetDistribution(scenario.LinieB);

        reasoning = Scenario.GetReasoning("Echitate după gen/rasă/vârstă", distributionA, distributionB);

        return distributionA < distributionB ? "A" : "B";
    }
}
