using InternShipApi.Core;
using InternShipApi.DatabaseObject.Request;
using InternShipApi.DatabaseObject.Response;
using InternShipApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Interfaces
{
    public interface IApplicationManager
    {
        Task<Result<string>> AddApplication(ApplicationDTO app);

        Task<Result<List<InternshipPosting>>> GetUserApp(TokenDTO token);

        Task<Result<List<CompanyPostCount>>> GetCompanyApp(TokenDTO token);


    }
}
