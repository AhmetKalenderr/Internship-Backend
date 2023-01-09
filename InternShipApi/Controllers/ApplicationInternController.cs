using InternShipApi.Core;
using InternShipApi.DatabaseObject.Request;
using InternShipApi.DatabaseObject.Response;
using InternShipApi.Entities;
using InternShipApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationInternController : Controller
    {
        private readonly IApplicationManager manager;
        public ApplicationInternController(IApplicationManager _manager)
        {
            manager = _manager;
        }
        [HttpPost("appIntern")]
        public Task<Result<string>> AppIntern([FromBody]ApplicationDTO app)
        {
            return manager.AddApplication(app);
        }


        //[HttpPost("userApp")]
        //public Task<Result<List<InternshipPosting>>> UserApp([FromBody] TokenDTO token)
        //{
        //    return manager.GetUserApp(token);
        //}

        //[HttpPost("companyPost")]

        //public Task<Result<List<CompanyPostCount>>> CompanyPost([FromBody]TokenDTO token)
        //{
        //    return manager.GetCompanyApp(token);
        //}
    }
}
