using AutoMapper;
using Primeiro.Dtos;
using Primeiro.Models;

namespace Primeiro.Profiles
{
     public class PrimarysProfile : Profile
     {
        public PrimarysProfile()
        {
            CreateMap<Primary, PrimaryReadDto>();

            CreateMap<PrimaryCreateDto, Primary>();

            CreateMap<PrimaryUpdateDto, Primary>();

            CreateMap<Primary, PrimaryUpdateDto>();
        }

     }

}