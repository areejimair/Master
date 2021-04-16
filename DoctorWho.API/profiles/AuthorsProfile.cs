using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.DB.Models;
namespace DoctorWho.API.profiles
{
    public class AuthorsProfile:Profile
    {
        public AuthorsProfile()
        {
            CreateMap<DoctorWho.DB.Models.TblAuthor, Models.Dto.AuthorDto>().ForMember(
                    dest => dest.AuthorId,
                    opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(
                    dest => dest.AuthorName,
                    opt => opt.MapFrom(src => src.AuthorName));
            ;

        }
    }
}
