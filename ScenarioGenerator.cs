namespace Tramvai;

public class ScenarioGenerator
{
    private static readonly Random rnd = new();

    public static Person GeneratePerson()
        => new((Race)rnd.Next(0, 3), (Gender)rnd.Next(0, 2), (Age)rnd.Next(0, 3));

    public static Scenario GenerateScenario()
    {
        Scenario scenario = new();

        int nr1 = rnd.Next(1, 6), nr2 = rnd.Next(1, 6);

        for (int i = 0; i < nr1; i++)
        {
            scenario.LinieA.Add(GeneratePerson());
        }

        for (int i = 0; i < nr2; i++)
        {
            scenario.LinieB.Add(GeneratePerson());
        }

        return scenario;
    }
}
