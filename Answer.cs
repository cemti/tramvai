namespace Tramvai;

// Romanian for serialisation
public record struct Answer(Scenario Scenariu, string RaspunsUtilizator, string RaspunsLlm, string JustificareLlm, string TipAlgo, string RaspunsAlgo, string JustificareAlgo);
