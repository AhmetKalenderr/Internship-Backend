using InternShipApi.Entities;
using System.Threading.Tasks;

namespace InternShipApi.Interfaces
{
    public interface ICompanyRepository
    {
        Task AddCompany(Company company);
    }
}
