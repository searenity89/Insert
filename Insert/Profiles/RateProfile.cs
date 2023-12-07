using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Insert.Dtos;
using Insert.Entities;
using Insert.Models;

namespace Insert.Profiles
{
    public class RateProfile : Profile
    {
        public RateProfile()
        {
            CreateMap<RateDto, RateModel>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Currency));

            CreateMap<RateModel, Rate>();
        }
    }
}