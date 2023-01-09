using InternShipApi.DatabaseObject.Request;
using System.Threading.Tasks;

namespace Appointment.Interfaces.IRepository
{
    public interface IMailVerifiedRepository
    {
        bool isMailVerified(LoginUser user);
        Task VerifyMail(string email);
        void AddMailVerified(string emailAddress);
    }
}
