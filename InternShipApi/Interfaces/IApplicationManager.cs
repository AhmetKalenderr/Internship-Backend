using InternShipApi.Core;
using InternShipApi.DatabaseObject.Request;
using InternShipApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Interfaces
{
    public interface IApplicationManager
    {
        Task<Result<string>> AddApplication(ApplicationDTO app);

        Task<Result<List<InternshipPosting>>> GetUserApp(TokenDTO token);


    }
}
