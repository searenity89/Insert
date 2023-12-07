using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Insert.Dtos;
using Insert.Models;

namespace Insert.Profiles
{
    public class MidRateTableProfile : Profile
    {
        public MidRateTableProfile()
        {
            CreateMap<MidRateTableDto, MidRateTableModel>()
                .ForMember(dst => dst.TableName, opt => opt.MapFrom(src => src.Table));
        }
    }
}