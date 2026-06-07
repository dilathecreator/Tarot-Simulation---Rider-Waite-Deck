using TarotSim.Core.Models;

namespace TarotSim.Core.Services;

public interface IDeckService
{
    void Shuffle();
    List<DrawnCard> Draw(int count);
}
