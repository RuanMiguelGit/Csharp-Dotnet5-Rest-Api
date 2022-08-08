using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FilmesApi.Profiles
{
    public class UsuarioProfile : Profile
    {
          public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}
