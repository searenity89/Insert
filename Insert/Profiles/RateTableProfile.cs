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
    public class RateTableProfile : Profile
    {
        public RateTableProfile()
        {
            CreateMap<RateTableDto, RateTableModel>()
                .ForMember(dst => dst.TableName, opt => opt.MapFrom(src => src.Table));

            CreateMap<RateTableModel, RateTable>();
        }
    }
}