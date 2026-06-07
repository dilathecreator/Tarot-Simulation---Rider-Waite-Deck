using TarotSim.Core.Enums;
using TarotSim.Core.Models;

namespace TarotSim.Core.Services;

public class SpreadService : ISpreadService
{
    private static readonly IReadOnlyDictionary<SpreadType, SpreadConfiguration> Configurations =
        new Dictionary<SpreadType, SpreadConfiguration>
        {
            [SpreadType.Single] = new(
                SpreadType.Single,
                "Single Card",
                1,
                "A single card for quick insight or daily guidance.",
                ["Your Card"]),
            [SpreadType.ThreeCard] = new(
                SpreadType.ThreeCard,
                "Three Card Spread",
                3,
                "Past, present, and future perspectives on your question.",
                ["Past", "Present", "Future"]),
            [SpreadType.CelticCross] = new(
                SpreadType.CelticCross,
                "Celtic Cross",
                10,
                "A classic ten-card spread for deep, comprehensive readings.",
                [
                    "Present Situation",
                    "The Challenge",
                    "Distant Past",
                    "Recent Past",
                    "Best Outcome",
                    "Immediate Future",
                    "Your Approach",
                    "External Influences",
                    "Hopes and Fears",
                    "Final Outcome"
                ]),
            [SpreadType.Custom] = new(
                SpreadType.Custom,
                "Custom Spread",
                0,
                "Draw any number of cards with generically named positions.",
                [])
        };

    public SpreadConfiguration GetConfiguration(SpreadType type)
    {
        if (!Configurations.TryGetValue(type, out var configuration))
        {
            throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown spread type.");
        }

        return configuration;
    }

    public List<SpreadConfiguration> GetAllConfigurations() =>
        Configurations.Values.ToList();

    public static string[] GenerateCustomPositionNames(int cardCount)
    {
        if (cardCount < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(cardCount), "Card count must be at least 1.");
        }

        return Enumerable.Range(1, cardCount)
            .Select(i => $"Card {i}")
            .ToArray();
    }
}
