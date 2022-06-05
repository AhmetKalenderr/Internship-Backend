using AutoMapper;
using InternShipApi.Core;
using InternShipApi.DatabaseObject.Request;
using InternShipApi.Entities;
using InternShipApi.Interfaces;
using InternShipApi.Services.Utility;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternShipApi.Services.Business
{
    public class ApplicationManager : IApplicationManager
    {
        private readonly IApplicationRepository repo;
        private readonly IMapper mapper;
        readonly TokenUtility tokenUtility= new();
        public ApplicationManager(IApplicationRepository _repo,IMapper _mapper)
        {
            mapper = _mapper;
            repo = _repo;
        }
        public async Task<Result<string>> AddApplication(ApplicationDTO app)
        {
            ApplicationIntern intern = mapper.Map(app, new ApplicationIntern());
            intern.UserId = tokenUtility.getUserFromToken(app.Token).Id;
            intern.AppTime = DateTime.Now;

            if (repo.CheckIfUserApp(intern))
            {
                await repo.AddApplication(intern);
                return new Result<string>
                {

                    Data = "",
                    Success = repo.CheckIfUserApp(intern),
                    Message = "Başvuru Yapıldı"
                };
            }
            else
            {
                return new Result<string>
                {
                    Data = "",
                    Success = repo.CheckIfUserApp(intern),
                    Message = "Daha önce bu ilana başvurdunuz"
                };
            }
          
        }

      

        public async Task<Result<List<InternshipPosting>>> GetUserApp(TokenDTO token)
        {
            return new Result<List<InternshipPosting>>
            {
                Success = true,
                Data = await repo.GetUserApp(tokenUtility.getUserFromToken(token.Token).Id),
                Message = "Başarılı"
            };
        }
    }
}
