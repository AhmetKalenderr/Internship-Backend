using InternShipApi.Core;
using InternShipApi.DatabaseObject.Request;
using InternShipApi.Entities;
using System.Threading.Tasks;

namespace InternShipApi.Interfaces
{
    public interface ICompanyManager
    {
        Task<Result<string>> AddCompany(Company company);

        Task<Result<string>> LoginCompany(LoginCompany c);
    }
}
