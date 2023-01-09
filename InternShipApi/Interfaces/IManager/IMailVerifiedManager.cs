using InternShipApi.Core;
using InternShipApi.DatabaseObject.Request;
using System.Threading.Tasks;

namespace Appointment.Interfaces.IManager
{
    public interface IMailVerifiedManager
    {
        Result<bool> isMailVerified(LoginUser user);

        Task<Result<string>> MailVerify(string email);
        string SetEmailVerified(string email);
    }
}
