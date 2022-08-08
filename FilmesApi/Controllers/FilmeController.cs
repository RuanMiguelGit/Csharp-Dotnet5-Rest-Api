using AutoMapper;
using FilmesApi.Data;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesApi.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;



namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService) 
        {
          _filmeService = filmeService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
          ReadFilmeDto readDto =  _filmeService.AdicionaFilme(filmeDto);
           
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = readDto.Id }, readDto);
        }
        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int xablau)
        {
            List<ReadFilmeDto> readDto =  _filmeService.RecuperaFilmes(xablau);
            if(readDto != null) {
                return Ok(readDto);
            }
          
            return NotFound();
      
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {

            ReadFilmeDto readDto = _filmeService.RecuperaFilmesPorId(id);
            if(readDto != null){
                return Ok(readDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result result = _filmeService.AtualizaFilme(id, filmeDto);
            if(result.IsFailed) return NotFound();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result result = _filmeService.DeletaFilme(id);
            if(result.IsFailed) return NotFound();
            return NoContent();
        }
    }

}
