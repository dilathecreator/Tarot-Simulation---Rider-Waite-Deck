using TarotSim.Core.Enums;
using TarotSim.Core.Models;

namespace TarotSim.Core.Services;

public interface ISpreadService
{
    SpreadConfiguration GetConfiguration(SpreadType type);
    List<SpreadConfiguration> GetAllConfigurations();
}
