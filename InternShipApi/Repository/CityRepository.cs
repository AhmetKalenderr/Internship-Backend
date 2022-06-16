using InternShipApi.Entities;
using InternShipApi.Interfaces.IRepository;
using InternShipApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternShipApi.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly InternDatabaseContext db;
        public CityRepository(InternDatabaseContext _db)
        {
            db = _db;
        }
        public async Task<List<City>> GetAllCity()
        {
            return await db.Cities.ToListAsync();
        }
    }
}
