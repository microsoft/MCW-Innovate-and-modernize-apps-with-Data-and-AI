using System.Collections.Generic;
using System.Threading.Tasks;
using MachineTelemetryRead.Models;

namespace MachineTelemetryRead.Interfaces
{
    public interface IEventRepository
    {
        Task<List<MachineTelemetry>> GetAllEventsAsync(int limit, int skip);
    }
}