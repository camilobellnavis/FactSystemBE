using AutoMapper;
using FactSystem.Application.DTOs.Enums;
using FactSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactSystem.Application.MapperProfiles
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<Status, StatusDto>();

        }
    }
}
