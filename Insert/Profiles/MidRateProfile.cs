using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Insert.Dtos;
using Insert.Models;

namespace Insert.Profiles
{
    public class MidRateProfile : Profile
    {
        public MidRateProfile()
        {
            CreateMap<MidRateDto, MidRateModel>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Currency))
                .ForMember(dst => dst.Value, opt => opt.MapFrom(src => src.Mid));
        }
    }
}