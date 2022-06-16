using InternShipApi.Core;
using InternShipApi.Entities;
using InternShipApi.Interfaces.IManager;
using InternShipApi.Interfaces.IRepository;
using InternShipApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Services.Business
{
    public class CityManager : ICityManager
    {
        private readonly ICityRepository repo;
        public CityManager(ICityRepository _repo)
        {
            repo = _repo;
        }
        public  async Task<Result<List<City>>> GetAllCity()
        {
            return new Result<List<City>>
            {
                Data = await repo.GetAllCity(),
                Success = true,
                Message = "Başarılı"
            };
        }
    }
}
