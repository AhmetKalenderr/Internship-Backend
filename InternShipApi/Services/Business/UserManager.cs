using Appointment.Services.Utility;
using InternShipApi.Core;
using InternShipApi.DatabaseObject;
using InternShipApi.DatabaseObject.Request;
using InternShipApi.DatabaseObject.Response;
using InternShipApi.Entities;
using InternShipApi.Interfaces;
using InternShipApi.Models;
using InternShipApi.Services.Utility;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternShipApi.Services.Business
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        private readonly InternDatabaseContext db;
        readonly TokenUtility tokenUtility = new();

        string Data;
        string Message = string.Empty;
        bool Success = false;

        public UserManager(IUserRepository userRepository,InternDatabaseContext db)
        {
            this.db = db;
            this.userRepository = userRepository;
        }

        public async Task<Result<string>> AddUser(User user)
        {
            if (!RegexCheckUtility.IsValidEmail(user.Email))
            {
                Message = "Email formatı geçersiz";
                Success = false;
               
            }else
            {
                List<User> list = db.Users.ToList();
                List<City> list2 = db.Cities.ToList();
                if (db.Users.FirstOrDefaultAsync(u => u.Email == user.Email).Result != null)
                {
                    Message = "Zaten Kayıtlı bir Email Girdiniz";
                    Success = false;
                } 
                else
                {
                    Message = "Kayıt Başarılı";
                    Success = true;
                    await  userRepository.AddUser(user);
                }
            }
            return new Result<string>
            {
                Data = Message,
                Success = Success,
            };
        }

        public async Task<Result<string>> LoginUser(LoginUser user)
        {
            if (db.Users.FirstOrDefaultAsync(s => s.Email == user.Email).Result != null)
            {
                if (db.Users.FirstOrDefaultAsync(s => s.Email == user.Email).Result.Password == user.Password)
                {
                    if (db.MailVerifies.FirstOrDefaultAsync(e => e.MailAddress == user.Email).Result.IsVerified)
                    {
                        Data = tokenUtility.GenerateTokenUser(db.Users.FirstOrDefaultAsync(s => s.Email == user.Email).Result);
                        Success = true;
                        Message = "Giriş Başarılı";
                    }
                    else
                    {
                        Data = null;
                        Success = false;
                        Message = $@"Lütfen {user.Email} Mail Adresinizi doğrulayın!!";
                    }
                }
                else
                {
                    Success = false;
                    Message = "Kullancı Adı veya Şifre Hatalı";
                }

            }
            else
            {
                Success = false;
                Message = "Kullancı Adı veya Şifre Hatalı";
            }
            return  new Result<string>
            {
                Success = Success,
                Message = Message,
                Data = Data
            };
        }

        public async Task<Result<List<UserFromApp>>> GetUsersFromApp(int id)
        {
            return new Result<List<UserFromApp>>
            {
                Data = await userRepository.GetUsers(id),
                Message = "Başarılı",
                Success = true
            };
        }
    }
}
