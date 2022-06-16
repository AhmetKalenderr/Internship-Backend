using InternShipApi.DatabaseObject.Response;
using InternShipApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);

        Task<List<UserFromApp>> GetUsers(int id);
    }
}
