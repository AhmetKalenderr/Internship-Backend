using InternShipApi.Core;
using InternShipApi.Entities;
using InternShipApi.Interfaces;
using System.Threading.Tasks;
using InternShipApi.Models;
using InternShipApi.Services.Utility;
using System.Linq;
using System;
using InternShipApi.DatabaseObject.Request;
using Microsoft.EntityFrameworkCore;

namespace InternShipApi.Services.Business
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly InternDatabaseContext db;
        readonly TokenUtility utility = new();
        bool Success;
        string Data;
        string Message;
        public CompanyManager(InternDatabaseContext db,ICompanyRepository companyRepository)
        {
            this.db = db;
            _companyRepository = companyRepository;
        }

        public async Task<Result<string>> AddCompany(Company company)
        {
            Console.WriteLine(company.Email);

            if (!RegexCheckUtility.IsValidEmail(company.Email)) 
            {
                Message = "Email formatı geçersiz";
                Success = false;
            }
            else if(db.Companies.FirstOrDefault(c => c.Email == company.Email) != null)
                {
                    Message = "Zaten Kayıtlı bir Email Girdiniz";
                    Success = false;
                }
            else if (!company.Email.EndsWith(company.WebSite))
            {
                Message = "Websitesi ile Email domainleri eşleşmiyor";
                Success = false;
            } else
            {
                Message = "Kayıt Başarılı";
                Success = true;
                await _companyRepository.AddCompany(company);
               
            }

            return new Result<string>
            {
                Success = Success,
                Data = Message,
            };
            
        }


        public async Task<Result<string>> LoginCompany(LoginCompany c)

        {
            try
            {
                Company com = db.Companies.FirstOrDefaultAsync(s => s.Email == c.Email).Result;

                if (com != null)
                {
                    if (com.PassWord == c.Password)
                    {
                        Success = true;
                        Message = "Giriş Başarılı";
                        Data = utility.GenerateTokenCompany(com);
                    }
                    else
                    {
                        Success = false;
                        Message = "Email veya şifre hatalı";
                    }
                }
                else
                {
                    Success=false;
                    Message = "Email veya şifre hatalı";
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return  new Result<string>
            {
                Success = Success,
                Message = Message,
                Data = Data
            };
        }
    }
}
