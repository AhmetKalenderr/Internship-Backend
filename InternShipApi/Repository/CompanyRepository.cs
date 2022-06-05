using InternShipApi.Entities;
using InternShipApi.Interfaces;
using InternShipApi.Models;
using System.Threading.Tasks;

namespace InternShipApi.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly InternDatabaseContext db;
        public CompanyRepository(InternDatabaseContext db)
        {
            this.db = db;
        }
        public async Task AddCompany(Company company)
        {
           await db.Companies.AddAsync(company);
            await db.SaveChangesAsync();
        }
    }
}
