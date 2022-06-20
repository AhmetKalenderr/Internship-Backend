using InternShipApi.DatabaseObject.Response;
using InternShipApi.Entities;
using InternShipApi.Interfaces;
using InternShipApi.Models;
using InternShipApi.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternShipApi.Repository
{
    public class UserRepository : IUserRepository
    {
        InternDatabaseContext _databaseContext;
        public UserRepository(InternDatabaseContext db)
        {
            _databaseContext = db;
        }
        public async Task AddUser(User user)
        {            
                await _databaseContext.Users.AddAsync(user);
                await _databaseContext.SaveChangesAsync();    

        }

        public async Task<List<UserFromApp>> GetUsers(int id)
        {
            List<ApplicationIntern> apps = _databaseContext.ApplicationIntern.Where(a => a.PostId == id).ToList();

            List<UserFromApp> users = new List<UserFromApp>();

            foreach (var app in apps)
            {
                User user = await _databaseContext.Users.FindAsync(app.UserId);
                users.Add(new UserFromApp { AppTime =  app.AppTime.ToString(), BornYear = user.BornYear, Email = user.Email, Name = user.Name, school = _databaseContext.Schools.Find(user.SchoolId), Surname = user.Surname });
            }

            return users;

        }
    }
}
