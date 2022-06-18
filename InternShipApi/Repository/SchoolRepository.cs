using InternShipApi.Entities;
using InternShipApi.Interfaces.IRepository;
using InternShipApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly InternDatabaseContext db;
        public SchoolRepository(InternDatabaseContext _db)
        {
            db = _db;
        }
        public async Task<List<School>> getAllSchool()
        {
            return await db.Schools.ToListAsync(); 
        }
    }
}
