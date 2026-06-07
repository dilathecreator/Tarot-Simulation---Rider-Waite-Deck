using TarotSim.Core.Enums;

namespace TarotSim.Core.DTOs;

public record DrawRequest(
    SpreadType SpreadType,
    int? CustomCardCount);
