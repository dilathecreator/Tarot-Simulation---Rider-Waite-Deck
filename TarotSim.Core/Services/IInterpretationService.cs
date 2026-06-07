using TarotSim.Core.Models;

namespace TarotSim.Core.Services;

public interface IInterpretationService
{
    Task<string> Interpret(Reading reading, CancellationToken cancellationToken = default);
}
