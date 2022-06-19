using InternShipApi.Core;
using InternShipApi.DatabaseObject.Request;
using InternShipApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Interfaces
{
    public interface IInternshipPostingManager
    {
        Task<Result<string>> AddPosting(AddInternshipPostingDto post);

        Task<Result<List<InternshipPosting>>> GetById(int id);

        Task<Result<List<InternshipPosting>>> GetByCompanyId(TokenDTO token);
        Task<Result<List<InternshipPosting>>> GetByCityId(int id);
        Task<Result<List<InternshipPosting>>> GetAllPosting();

        Task<Result<List<InternshipPosting>>> GetByFilter(FilterBody filter);
    }
}
