//using InternShipApi.DatabaseObject;
//using InternShipApi.DatabaseObject.Request;
//using InternShipApi.Entities;
//using InternShipApi.Interfaces;
//using InternShipApi.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace InternShipApi.Repository
//{
//    public class InternshipPostingRepository : IInternshipPostingRepository
//    {
//        readonly InternDatabaseContext db;
//        public InternshipPostingRepository(InternDatabaseContext _db)
//        {
//            db = _db;
//        }

//        public async Task AddPosting(InternshipPosting post)
//        {
//            await db.InternshipPostings.AddAsync(post);
//            await db.SaveChangesAsync();
//        }

//        public async Task<List<InternshipPosting>> GetAll()
//        {
//            return await db.InternshipPostings.Include(c => c.position).Include(c => c.city).Include(c => c.company).ToListAsync();
//        }

//        public async Task<List<InternshipPosting>> GetByCityId(int id)
//        {
//            return await db.InternshipPostings.Where(i => i.CityId == id).Include(c => c.position).Include(c => c.city).Include(c => c.company).ToListAsync();
//        }

//        public async Task<List<InternshipPosting>> GetByCompanyId(int id)
//        {
//            return await db.InternshipPostings.Where(i => i.companyId == id).Include(c => c.position).Include(c => c.city).Include(c => c.company).ToListAsync();
//        }

//        public  async Task<List<InternshipPosting>> GetById(int id)
//        {
//            return await db.InternshipPostings.Where(i => i.positionId == id).Include(c=> c.position).Include(c=> c.city).Include(c=>c.company).ToListAsync();
//        }

//        public async Task<List<InternshipPosting>> GetByFilter(FilterBody filter)
//        {
//            return await db.InternshipPostings.Where(i => i.CityId == filter.CityId).Where(i=> i.positionId == filter.PositionId).Include(c => c.position).Include(c => c.city).Include(c => c.company).ToListAsync();
//        }
//    }
//}
