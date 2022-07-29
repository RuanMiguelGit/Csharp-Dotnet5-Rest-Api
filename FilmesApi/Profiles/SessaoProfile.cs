using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<createSessaoDto, Sessao>();
            CreateMap<Sessao, readSessaoDto>();
            // .ForMember(dto=> dto.HorarioDeInicio, opts=>opts.MapFrom(dto=> dto.HoradoEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));
        }
    }
}
