using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesApi.Services;
using FluentResults;

namespace FilmesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : Controller
    {
        // private readonly ILogger<CadastroController> _logger;

        // public CadastroController(ILogger<CadastroController> logger)
        // {
        //     _logger = logger;
        // }
        [HttpPost]
        public IActionResult CadastraUsuario(CreateUsuarioDto usuarioDto)
        {
            return Ok();
        }
   
    }
}