using Appointment.Interfaces.IManager;
using Appointment.Interfaces.IRepository;
using Appointment.Services.Utility;
using InternShipApi.Core;
using InternShipApi.DatabaseObject.Request;
using System.Threading.Tasks;

namespace Appointment.Services.Business
{
    public class MailVerifiedManager : IMailVerifiedManager
    {
        private readonly IMailVerifiedRepository repo;
        public MailVerifiedManager(IMailVerifiedRepository _repo)
        {
            repo = _repo;
        }
        public Result<bool> isMailVerified(LoginUser user)
        {
            return new Result<bool>
            {
                Data = repo.isMailVerified(user),
                Message = repo.isMailVerified(user) == true ? "Mail doğrulaması yapıldı" : "Giriş yapabilmeniz için mail adresinizi doğrulamanız gerekir",
                Success = repo.isMailVerified(user)
            };
        }

        public async Task<Result<string>> MailVerify(string email)
        {
            
                string errorMessage = string.Empty;
                try
                {
                    await repo.VerifyMail(email);
                }
                catch (System.Exception ex)
                {
                    errorMessage = ex.Message;
                }
                return new Result<string>
                {
                    Data = "Başarılı",
                    Message = "Mail Adresiniz Doğrulandı",
                    Success = true,
                };
            
        }

        public string SetEmailVerified(string emailAddress)
        {
            SendMail sm = new SendMail();
            sm.SendVerifiedMails(emailAddress);
            repo.AddMailVerified(emailAddress);
            return "Doğrulama maili gönderildi";
        }
    }
}
