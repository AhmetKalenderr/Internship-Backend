using InternShipApi.DatabaseObject.Response;
using InternShipApi.Entities;
using InternShipApi.Interfaces;
using InternShipApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternShipApi.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly InternDatabaseContext db;
        public ApplicationRepository(InternDatabaseContext _db)
        {
            db = _db;
        }
        public async Task AddApplication(ApplicationIntern app)
        {
            try
            {
                await db.ApplicationIntern.AddAsync(app);
                await db.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        


        public async Task<List<InternshipPosting>> GetUserApp(int id)
        {
           List<ApplicationIntern> apps =  db.ApplicationIntern.Where(i => i.UserId == id).ToList();
           List<InternshipPosting> postList = new();

            foreach (var app in apps)
            {
                postList.Add( await db.InternshipPostings.Include(i => i.city).Include(i => i.position).Include(i => i.company).FirstOrDefaultAsync(i => i.Id == app.PostId));
            }
            Console.WriteLine(postList.Count);
            return postList;
        
        }

        public bool CheckIfUserApp(ApplicationIntern app)
        {
            List<ApplicationIntern> userApps = db.ApplicationIntern.Where(a => a.UserId == app.UserId).ToList();
            bool check = true;

            foreach (var apps in userApps)
            {
                if (app.PostId == apps.PostId)
                {
                    check = false;
                }
            }
            return check;
        }

        public async Task<List<CompanyPostCount>> GetCompanyPostCount(int id)
        {
            List<InternshipPosting> posts = await db.InternshipPostings.Where(i => i.companyId == id).ToListAsync();

            List<CompanyPostCount> companyPost = new List<CompanyPostCount>();

            foreach (var post in posts)
            {
                companyPost.Add(new CompanyPostCount { Count = Convert.ToInt32(db.ApplicationIntern.Where(i => i.PostId == post.Id).ToList().Count), post= db.InternshipPostings.Include(i => i.position).Include(i => i.company).Include(i => i.city).FirstOrDefaultAsync(p => p.Id == post.Id).Result });
            }

            return companyPost;

        }
    }
}
