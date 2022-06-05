using InternShipApi.Core;
using InternShipApi.Entities;
using InternShipApi.Interfaces;
using InternShipApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Repository
{
    public class InternshipPositionRepository : IInternshipPositionRepository
    {
        private readonly InternDatabaseContext db;
        public InternshipPositionRepository(InternDatabaseContext _db)
        {
            db = _db;
        }

        public async Task AddPosting(InternshipPosition position)
        {
            await db.InternshipPositions.AddAsync(position);
            await db.SaveChangesAsync();
        }

        public async Task<List<InternshipPosition>> GetAllPositions()
        {
            return await db.InternshipPositions.ToListAsync();
        }
    }
}
