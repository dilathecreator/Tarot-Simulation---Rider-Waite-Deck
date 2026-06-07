using TarotSim.Core.Models;

namespace TarotSim.Core.DTOs;

public record ReadingResponse(
    Guid Id,
    string SpreadName,
    List<DrawnCard> DrawnCards,
    string Interpretation,
    DateTime CreatedAt);
