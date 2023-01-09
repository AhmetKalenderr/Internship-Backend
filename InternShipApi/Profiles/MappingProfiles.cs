using AutoMapper;
using InternShipApi.DatabaseObject.Request;
using InternShipApi.Entities;
using InternShipApi.Models;
using System;

namespace InternShipApi.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            
            CreateMap<UserDTO, User>();
            CreateMap<ApplicationDTO, ApplicationIntern>();
            CreateMap<AddInternshipPositionDto, InternshipPosition>();
            CreateMap<CompanyDto, Company>();
            //CreateMap<AddInternshipPostingDto, InternshipPosting>()
            //    .ForMember(i => i.PostEndTime, a => a.MapFrom(s => DateTime.Now.AddDays(s.PostExpireDay)))
            //    ;
            
        }
    }
}
