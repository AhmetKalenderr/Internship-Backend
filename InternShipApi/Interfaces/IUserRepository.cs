using InternShipApi.Entities;
using System.Threading.Tasks;

namespace InternShipApi.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
    }
}
