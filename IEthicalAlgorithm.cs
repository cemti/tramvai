namespace Tramvai;

public interface IEthicalAlgorithm
{
    string Decide(Scenario scenario, out string reasoning); // returns "A" or "B"
}
