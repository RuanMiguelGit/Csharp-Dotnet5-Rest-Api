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
        private UserManager<CustomIdentityUser> _userManager;
        private EmailService  _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;
        
        public CadastroService(IMapper mapper, UserManager<CustomIdentityUser>  userManager, EmailService emailService, RoleManager<IdentityRole<int>>  roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            // _roleManager = roleManager;            
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {

            Usuario usuario = _mapper.Map<Usuario>(createDto);
            CustomIdentityUser usuarioIdentity = _mapper.Map<CustomIdentityUser>(usuario);
            Task<IdentityResult> resultIdentity = _userManager.CreateAsync(usuarioIdentity, createDto.Password);
            // var createRoleResult =  _roleManager.CreateAsync(new IdentityRole<int>("admin")).Result;
            // var usuarioRoleResult =  _userManager.AddToRoleAsync(usuarioIdentity, "admin").Result;
            _userManager.AddToRoleAsync(usuarioIdentity, "regular");
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
