using System.Numerics;

namespace Tramvai;

public class Scenario
{
    public static string GetReasoning<T>(string scenarioName, T numA, T numB)
        where T : INumber<T>
    {
        var reasoning = $"{scenarioName} pe traiectoria A ({numA}) ";

        reasoning += numA > numB
                      ? '>'
                      : numA < numB
                        ? '<'
                        : '=';

        reasoning += $" {scenarioName} pe traiectoria B ({numB})";
        return reasoning;
    }
    
    public List<Person> LinieA { get; set; } = [];
    public List<Person> LinieB { get; set; } = [];

    public override string ToString()
    {
        string l1 = string.Join("\n", LinieA.Select(p => p.ToString()));
        string l2 = string.Join("\n", LinieB.Select(p => p.ToString()));
        return $"Linia 1:\n{l1}\n\nLinia 2:\n{l2}";
    }
}
