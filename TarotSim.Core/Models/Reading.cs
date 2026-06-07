using TarotSim.Core.Enums;

namespace TarotSim.Core.Models;

public record Reading(
    Guid Id,
    SpreadType SpreadType,
    int CardCount,
    List<DrawnCard> DrawnCards,
    string Interpretation,
    DateTime CreatedAt);
