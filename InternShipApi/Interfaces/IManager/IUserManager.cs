using InternShipApi.Core;
using InternShipApi.DatabaseObject.Request;
using InternShipApi.DatabaseObject.Response;
using InternShipApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Interfaces
{
    public interface IUserManager
    {
        Task<Result<string>> AddUser(User user);

        Task<Result<string>> LoginUser(LoginUser user);

        Task<Result<List<UserFromApp>>> GetUsersFromApp(int id);
    }
}
