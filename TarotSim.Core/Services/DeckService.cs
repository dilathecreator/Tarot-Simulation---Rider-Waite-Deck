using System.Reflection;
using System.Text.Json;
using TarotSim.Core.Models;

namespace TarotSim.Core.Services;

public class DeckService : IDeckService
{
    private const double ReversalProbability = 0.30;
    private readonly List<TarotCard> _cards;
    private readonly Random _random;

    public DeckService()
        : this(new Random())
    {
    }

    internal DeckService(Random random)
    {
        _random = random;
        _cards = LoadCards();
    }

    public void Shuffle()
    {
        for (var i = _cards.Count - 1; i > 0; i--)
        {
            var j = _random.Next(i + 1);
            (_cards[i], _cards[j]) = (_cards[j], _cards[i]);
        }
    }

    public List<DrawnCard> Draw(int count)
    {
        if (count < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be at least 1.");
        }

        if (count > _cards.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(count), $"Cannot draw {count} cards from a deck of {_cards.Count}.");
        }

        Shuffle();

        return _cards
            .Take(count)
            .Select(card => new DrawnCard(
                card,
                string.Empty,
                _random.NextDouble() < ReversalProbability))
            .ToList();
    }

    private static List<TarotCard> LoadCards()
    {
        var assembly = Assembly.GetExecutingAssembly();
        const string resourceName = "TarotSim.Core.Data.cards.json";

        using var stream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException($"Embedded resource '{resourceName}' was not found.");

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var cards = JsonSerializer.Deserialize<List<TarotCard>>(stream, options)
            ?? throw new InvalidOperationException("Failed to deserialize cards.json.");

        if (cards.Count != 78)
        {
            throw new InvalidOperationException($"Expected 78 cards, but found {cards.Count}.");
        }

        return cards;
    }
}
