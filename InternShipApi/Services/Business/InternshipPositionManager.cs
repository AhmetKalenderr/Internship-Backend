using InternShipApi.Core;
using InternShipApi.Entities;
using InternShipApi.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Services.Business
{
    public class InternshipPositionManager : IInternshipPositionManager
    {
        string Message;
        bool Success = false;
        private readonly IInternshipPositionRepository repo;

        public InternshipPositionManager(IInternshipPositionRepository _repo)
        {
            repo = _repo;
        }
        public async Task<Result<string>> AddPosition(InternshipPosition position)
        {
            if (position.Name.Length >= 0)
            {
                await repo.AddPosting(position);
                Message = $"{position.Name} isimli Pozisyon eklendi";
                Success = true;
            }
            return new Result<string>
            {
                Message = Message,
                Data = null,
                Success = Success
            };
        }

        public async Task<Result<List<InternshipPosition>>> GetAllPositions()
        {
           List<InternshipPosition> list =  await repo.GetAllPositions();

            return new Result<List<InternshipPosition>>
            {
                Data = list,
                Success = true,
                Message = "Başarılı",
            };
        }
    }
}
