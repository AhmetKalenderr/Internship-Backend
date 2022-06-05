using InternShipApi.Core;
using InternShipApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Interfaces
{
    public interface IInternshipPositionRepository
    {
        Task AddPosting(InternshipPosition position);
        Task<List<InternshipPosition>> GetAllPositions();
    }
}
