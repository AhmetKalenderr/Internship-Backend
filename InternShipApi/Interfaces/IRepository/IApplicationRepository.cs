using InternShipApi.DatabaseObject.Response;
using InternShipApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Interfaces
{
    public interface IApplicationRepository
    {
        Task AddApplication(ApplicationIntern app);

        // Task<List<InternshipPosting>> GetUserApp(int id);

        bool CheckIfUserApp(ApplicationIntern app);

        // Task<List<CompanyPostCount>> GetCompanyPostCount(int id);
    }
}
