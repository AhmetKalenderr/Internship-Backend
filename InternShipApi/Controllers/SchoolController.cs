using InternShipApi.Core;
using InternShipApi.Entities;
using InternShipApi.Interfaces.IManager;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Controllers
{
    [Route("api/[controller]")]
    public class SchoolController : Controller
    {
        private readonly ISchoolManager manager;
        public SchoolController(ISchoolManager _manager)
        {
            manager = _manager;
        }
        [HttpPost("getall")]
        public async Task<Result<List<School>>> GetAll()
        {
            return await manager.GetAllSchool();
        }
    }
}
