namespace Tramvai;

public class DeontologicalAlgorithm : IEthicalAlgorithm
{
    public string Decide(Scenario scenario, out string reasoning)
    {
        reasoning = "Nici o intervenție";
        return "B";
    }
}
