using InternShipApi.Core;
using InternShipApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Interfaces
{
    public interface IInternshipPositionManager
    {
        Task<Result<string>> AddPosition(InternshipPosition position);
        Task<Result<List<InternshipPosition>>> GetAllPositions();
    }
}
