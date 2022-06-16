using InternShipApi.Core;
using InternShipApi.Entities;
using InternShipApi.Interfaces.IManager;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Controllers
{
    [Route("api/[controller]")]
    public class CityController : Controller
    {
        private readonly ICityManager manager;
        public CityController(ICityManager _manager)
        {
            manager = _manager;
        }

        [HttpPost("getAllCity")]
        public  Task<Result<List<City>>> GetAll()
        {
            return  manager.GetAllCity();
        }
    }
}
