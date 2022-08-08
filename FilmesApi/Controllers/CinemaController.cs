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


namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
       
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
        _cinemaService = cinemaService;

        }
  

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {

            ReadCinemaDto readDto = _cinemaService.AdicionaCinema(cinemaDto);

            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoFilme)
        {
            List<ReadCinemaDto> readDto = _cinemaService.RecuperaCinemas(nomeDoFilme);
            if(readDto != null) {
                return Ok(readDto);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            ReadCinemaDto readDto = _cinemaService.RecuperaCinemasPorId(id);
            if(readDto != null){
                return Ok(readDto);
            }
            return NotFound();
        
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
           Result result = _cinemaService.AtualizaCinema(id, cinemaDto);
           if(result.IsFailed) return NotFound();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result result = _cinemaService.DeletaCinema(id);
            if(result.IsFailed) return NotFound();
            return NoContent();
        }

    }
}
