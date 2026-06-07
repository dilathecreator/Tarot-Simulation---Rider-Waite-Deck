namespace TarotSim.Core.Models;

public record DrawnCard(
    TarotCard Card,
    string PositionName,
    bool IsReversed);
