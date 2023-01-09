using Appointment.Entities;
using Appointment.Interfaces.IRepository;
using InternShipApi.DatabaseObject.Request;
using InternShipApi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment.Repository
{
    public class MailVerifiedRepository : IMailVerifiedRepository
    {
        private readonly InternDatabaseContext _db;
        public MailVerifiedRepository(InternDatabaseContext db)
        {
            _db = db;
        }

        public bool isMailVerified(LoginUser user)
        {
            try
            {
                var userId = _db.Users.SingleOrDefault(u => u.Email == user.Email).Id;
                return _db.MailVerifies.SingleOrDefault(c => c.userId == userId).IsVerified;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task VerifyMail(string email)
        {
            MailVerify mailVerify = _db.MailVerifies.FirstOrDefault(item => item.MailAddress == email);
            if (mailVerify == null)
            {
                throw new Exception("Kullanıcı bulunamadı");
            }
            mailVerify.IsVerified = true;
            await _db.SaveChangesAsync();
        }

        public void AddMailVerified(string mailAddress)
        {
            var userId = _db.Users.FirstOrDefault(i => i.Email == mailAddress).Id;
            MailVerify verify = new MailVerify() { IsVerified = false,MailAddress = mailAddress,userId= userId };
            _db.MailVerifies.Add(verify);
            _db.SaveChanges();
        }
    }
}
