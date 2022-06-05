using InternShipApi.Entities;
using InternShipApi.Interfaces;
using InternShipApi.Models;
using InternShipApi.Services.Utility;
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
    }
}
