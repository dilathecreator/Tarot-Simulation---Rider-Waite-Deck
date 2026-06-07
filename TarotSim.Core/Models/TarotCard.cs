namespace TarotSim.Core.Models;

public record TarotCard(
    int Id,
    string Name,
    string Arcana,
    string Suit,
    int Number,
    string Symbol,
    string Element,
    string UprightMeaning,
    string ReversedMeaning,
    string[] Keywords);
