using AutoMapper;
using InternShipApi.Core;
using InternShipApi.DatabaseObject.Request;
using InternShipApi.Entities;
using InternShipApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Controllers
{
    [Route("api/[controller]")]
    public class InternshipPositionController : Controller
    {
        private readonly IMapper imapper;
        private readonly IInternshipPositionManager manager;
        public InternshipPositionController(IMapper _imapper,IInternshipPositionManager _manager)
        {
            manager = _manager;
            imapper = _imapper;
        }

        [HttpPost("addPosition")]
        public async Task<Result<string>> AddPosition([FromBody] AddInternshipPositionDto positionDto)
        {
            return await manager.AddPosition(imapper.Map(positionDto, new InternshipPosition()));
        }

        [HttpPost("getAllPositions")]

        public async Task<Result<List<InternshipPosition>>> GetAllPositions()
        {
            return await manager.GetAllPositions();
        }
    }
}
