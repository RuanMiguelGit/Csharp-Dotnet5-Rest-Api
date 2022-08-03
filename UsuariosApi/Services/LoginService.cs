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
      private  SignInManager<IdentityUser<int>> _signInManager;
      private TokenService _tokenService;


    public LoginService( SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
    {
        _tokenService = tokenService;
        _signInManager = signInManager;
            
    }

    public Result LogaUsuario(LoginRequest request)
    {
        var resultIdentity = _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, false );
        if(resultIdentity.Result.Succeeded){
        var IdentityUser = _signInManager.UserManager.Users.FirstOrDefault(usuario=> usuario.NormalizedUserName == request.UserName.ToUpper());
        Token token =  _tokenService.CreateToken(IdentityUser);
         return Result.Ok().WithSuccess(token.Value);
        }
        
        
        return Result.Fail("O Login Falhou");
    }

        
    }
}