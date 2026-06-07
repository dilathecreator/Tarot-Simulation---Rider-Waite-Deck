using TarotSim.Core.Enums;

namespace TarotSim.Core.Models;

public record SpreadConfiguration(
    SpreadType Type,
    string DisplayName,
    int CardCount,
    string Description,
    string[] PositionNames);
