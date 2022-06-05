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
    public class InternshipPostingController : Controller
    {
        readonly IInternshipPostingManager manager;
        public InternshipPostingController(IInternshipPostingManager _manager)
        {
            manager = _manager;
        }

        [HttpPost("addPost")]
        public async Task<Result<string>> AddPost([FromBody] AddInternshipPostingDto postDto)
        {
            
            return await manager.AddPosting(postDto);
        }

        [HttpPost("getByPositionIdPost")]

        public async Task<Result<List<InternshipPosting>>> GetById(int id)
        {
            return await manager.GetById(id);
        }

        [HttpPost("getByCompanyIdPost")]

        public async Task<Result<List<InternshipPosting>>> GetByCompanyId([FromBody]TokenDTO token)
        {
            return await manager.GetByCompanyId(token);
        }

        [HttpPost("getByCityIdPost")]

        public async Task<Result<List<InternshipPosting>>> GetByCityId(int id)
        {
            return await manager.GetByCityId(id);
        }

        [HttpPost("getAllPost")]

        public async Task<Result<List<InternshipPosting>>> GetAllPosting()
        {
            return await manager.GetAllPosting();
        }
    }
}
