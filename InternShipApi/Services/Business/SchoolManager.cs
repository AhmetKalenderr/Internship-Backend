using InternShipApi.Core;
using InternShipApi.Entities;
using InternShipApi.Interfaces.IManager;
using InternShipApi.Interfaces.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Services.Business
{
    public class SchoolManager : ISchoolManager
    {
        private readonly ISchoolRepository repo;
        public SchoolManager(ISchoolRepository _repo)
        {
           repo = _repo;
        }

        public async Task<Result<List<School>>> GetAllSchool()
        {
            return new Result<List<School>>
            {
                Data = await repo.getAllSchool(),
                Success = true,
                Message = "Okullar Getirildi"
            };
        }
    }
}
