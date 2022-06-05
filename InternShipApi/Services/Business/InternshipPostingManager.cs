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
    public class InternshipPostingManager : IInternshipPostingManager
    {
        private readonly IInternshipPostingRepository repo;
        private readonly IMapper mapper;
        string Message;
        bool Success;
        readonly TokenUtility tokenUtility=new();

        public InternshipPostingManager(IInternshipPostingRepository _repo, IMapper _mapper)
        {
            mapper = _mapper;
            repo = _repo;
        }
        public async Task<Result<string>> AddPosting(AddInternshipPostingDto postDto)
        {
            Console.WriteLine(postDto.Token);
            InternshipPosting post = mapper.Map(postDto, new InternshipPosting());
            post.companyId = tokenUtility.getCompanyFromToken(postDto.Token).Id;
            post.CityId = tokenUtility.getCompanyFromToken(postDto.Token).CityId;
            post.PostStartTime = DateTime.Now;
            Message = "İlan eklendi";
            Success = true;
            
            await repo.AddPosting(post);
            
            return  new Result<string>
            {
                Success = Success,
                Message = Message,
                Data = Message
            };
        }

        public async Task<Result<List<InternshipPosting>>> GetByCityId(int id)
        {
            return new Result<List<InternshipPosting>>
            {
                Data = await repo.GetByCityId(id),
                Message = $"{id} City idli İlanlar getirildi",
                Success = true
            };
        }

        public async Task<Result<List<InternshipPosting>>> GetByCompanyId(TokenDTO token)
        {
            return new Result<List<InternshipPosting>>
            {
                Data = await repo.GetByCompanyId(tokenUtility.getCompanyFromToken(token.Token).Id),
                Message = $"Company idli İlanlar getirildi",
                Success = true
            };
        }

        public async Task<Result<List<InternshipPosting>>> GetById(int id)
        {
                return new Result<List<InternshipPosting>>
                {
                Data = await repo.GetById(id),
                Message = $"{id} Pozisyon idli İlanlar getirildi",
                Success = true
                };  
        }

        public async Task<Result<List<InternshipPosting>>> GetAllPosting()
        {
            return new Result<List<InternshipPosting>>
            {
                Data = await repo.GetAll(),
                Message = "Data Getirildi",
                Success = true
            };
        }
    }
}
