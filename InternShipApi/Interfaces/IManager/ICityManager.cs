using InternShipApi.Core;
using InternShipApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Interfaces.IManager
{
    public interface ICityManager
    {
        Task<Result<List<City>>> GetAllCity();
    }
}
