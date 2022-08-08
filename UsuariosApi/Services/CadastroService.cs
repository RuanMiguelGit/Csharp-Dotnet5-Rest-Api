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
using System.Web;


namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private IMapper _mapper; 
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService  _emailService;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>>  userManager, EmailService emailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {

            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password);
            if(resultIdentity.Result.Succeeded)
            {
                string code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;
                var encodedCode = HttpUtility.UrlEncode(code);
                _emailService.EnviarEmail(new[] {usuarioIdentity.Email}, "Link de Ativação", usuarioIdentity.Id, encodedCode);
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
