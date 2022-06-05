using AutoMapper;
using InternShipApi.Core;
using InternShipApi.DatabaseObject.Request;
using InternShipApi.Entities;
using InternShipApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InternShipApi.Controllers
{
    [Route("/api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyManager _companyManager;
        private readonly IMapper mapper;
        public CompanyController(ICompanyManager companyManager, IMapper mapper)
        {
            this.mapper = mapper;
            _companyManager = companyManager;
        }
        [HttpPost("addcompany")]
        public async Task<Result<string>> AddCompnay([FromBody]CompanyDto companyDto)
        {
            var c = _companyManager.AddCompany(mapper.Map(companyDto, new Company()));
            if (c.Result.Success)
            {
                return await _companyManager.AddCompany(mapper.Map(companyDto, new Company()));

            }
            else
            {
                Response.StatusCode = 402;
                return await _companyManager.AddCompany(mapper.Map(companyDto, new Company()));

            }
        }

        [HttpPost("loginCompany")]

        public Task<Result<string>> LoginCpmpany([FromBody]LoginCompany login)
        {
            if (_companyManager.LoginCompany(login).Result.Success)
            {
                return _companyManager.LoginCompany(login);
            }
            else
            {
                Response.StatusCode = 401;
                return _companyManager.LoginCompany(login);
            }
        }


        
    }
}
