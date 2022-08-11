using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Requests;
using UsuariosApi.Models;
using UsuariosApi.Services;


namespace UsuariosApi.Services
{
    public class LoginService
    {
      private  SignInManager<CustomIdentityUser> _signInManager;
      private TokenService _tokenService;


    public LoginService( SignInManager<CustomIdentityUser> signInManager, TokenService tokenService)
    {
        _tokenService = tokenService;
        _signInManager = signInManager;
            
    }

    public Result LogaUsuario(LoginRequest request)
    {
        var resultIdentity = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false );
        if(resultIdentity.Result.Succeeded){
        var IdentityUser = _signInManager.UserManager.Users.FirstOrDefault(usuario=> usuario.NormalizedUserName == request.UserName.ToUpper());
        Token token = _tokenService.CreateToken(IdentityUser, _signInManager.UserManager.GetRolesAsync(IdentityUser).Result.FirstOrDefault());
         return Result.Ok().WithSuccess(token.Value);
        }
        
        
        return Result.Fail("O Login Falhou");
    }
    public Result SolicitaResetSenhaUsuario(SolicitaSenhaRequest request)
    {
        var IdentityUser = _signInManager.UserManager.Users.FirstOrDefault(usuario=> usuario.NormalizedEmail== request.Email.ToUpper());
        if(IdentityUser != null) 
        {
            string codigoDeRecuperacao = _signInManager.UserManager.GeneratePasswordResetTokenAsync(IdentityUser).Result;
            return Result.Ok().WithSuccess(codigoDeRecuperacao);
        }
            return Result.Fail("Falha ao solicitar a redefinição");
    }

        public Result ResetSenhaUsuario(EfetuaResetRequest request)
        {
            var IdentityUser = _signInManager.UserManager.Users.FirstOrDefault(usuario=> usuario.NormalizedEmail== request.Email.ToUpper());
            IdentityResult resultadoIdentity = 
            _signInManager.UserManager.ResetPasswordAsync(IdentityUser, request.Token, request.Password).Result;
            if(resultadoIdentity.Succeeded) return Result.Ok().WithSuccess("Senha redefinida com sucesso");
            return Result.Fail("Falha ao redefinir a senha ");
        }

        
    }
}