using System.Text.Json.Serialization;

namespace Tramvai;

public record class Person(Race Rasa, Gender Gen, Age Varsta)
{
    [JsonIgnore]
    public string Emoji => (Rasa, Gen, Varsta) switch
    {
        (Race.Alb, Gender.Masculin, Age.Adult) => "👨🏻",
        (Race.Alb, Gender.Masculin, Age.Copil) => "🧒🏻",
        (Race.Alb, Gender.Masculin, Age.Batran) => "🧓🏻",

        (Race.Alb, Gender.Feminin, Age.Adult) => "👩🏻",
        (Race.Alb, Gender.Feminin, Age.Copil) => "👧🏻",
        (Race.Alb, Gender.Feminin, Age.Batran) => "👵🏻",


        (Race.Asiatic, Gender.Masculin, Age.Adult) => "👨",
        (Race.Asiatic, Gender.Masculin, Age.Copil) => "👦",
        (Race.Asiatic, Gender.Masculin, Age.Batran) => "🧓",

        (Race.Asiatic, Gender.Feminin, Age.Adult) => "👩",
        (Race.Asiatic, Gender.Feminin, Age.Copil) => "👧",
        (Race.Asiatic, Gender.Feminin, Age.Batran) => "👵",


        (Race.AfroAmerican, Gender.Masculin, Age.Adult) => "👨🏽",
        (Race.AfroAmerican, Gender.Masculin, Age.Copil) => "🧒🏽",
        (Race.AfroAmerican, Gender.Masculin, Age.Batran) => "🧓🏽",

        (Race.AfroAmerican, Gender.Feminin, Age.Adult) => "👩🏽",
        (Race.AfroAmerican, Gender.Feminin, Age.Copil) => "👧🏽",
        (Race.AfroAmerican, Gender.Feminin, Age.Batran) => "👵🏽",

        _ => throw new InvalidOperationException()
    };

    public override string ToString() => $"{Rasa} {Gen} {Varsta}";
}
