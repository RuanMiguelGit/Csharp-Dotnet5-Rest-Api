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

        // [HttpPut("{id}")]
        // public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        // {
        //     Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        //     if(cinema == null)
        //     {
        //         return NotFound();
        //     }
        //     _mapper.Map(cinemaDto, cinema);
        //     _context.SaveChanges();
        //     return NoContent();
        // }


        // [HttpDelete("{id}")]
        // public IActionResult DeletaCinema(int id)
        // {
        //     Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        //     if (cinema == null)
        //     {
        //         return NotFound();
        //     }
        //     _context.Remove(cinema);
        //     _context.SaveChanges();
        //     return NoContent();
        // }

    }
}
