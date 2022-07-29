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

        // [HttpPut("{id}")]
        // public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        // {
        //     // ReadFilmeDto readDto = _filmeService.AtualizaFilme( UpdateFilmeDto filmeDto);
        //     Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        //     if(filme == null){
        //         return NotFound();
        //     }

        //     _mapper.Map(filmeDto, filme);
        //     _context.SaveChanges();
        //     return NoContent();

        // }

        // [HttpDelete("{id}")]
        // public IActionResult DeletaFilme(int id)
        // {
        //       Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        //     if(filme == null){
        //         return NotFound();
        //     }
        //     _context.Remove(filme);
        //     _context.SaveChanges();
        //     return NoContent();
        // }
    }

}
