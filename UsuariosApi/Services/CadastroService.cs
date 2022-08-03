using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Dtos.Usuario;
using UsuariosApi.Models;
using UsuariosApi.Data.Requests;


namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private IMapper _mapper; 
        private UserManager<IdentityUser<int>> _userManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>>  userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {

            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password);
            if(resultIdentity.Result.Succeeded)
            {
                string code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                return Result.Ok().WithSuccess(code);
            }
                
            return Result.Fail("Houve uma falha no cadastro");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
          var identityUser = _userManager.Users.Where(u => u.Id == request.UsuarioId).FirstOrDefault(); 
            var IdentityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoDeAtivacao);
            if(IdentityResult.Result.Succeeded)
            {
                return Result.Ok();
            }
            return Result.Fail("Falha ao ativar a conta");

        }

    }
}
