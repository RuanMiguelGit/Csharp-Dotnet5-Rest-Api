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

namespace FilmesApi.Services
{
    public class CinemaService
    {
        private AppDbContext _context;
        private IMapper _mapper;


        public CinemaService(AppDbContext context, IMapper mapper)
        {
        _context = context;
        _mapper = mapper;
        }

        public ReadCinemaDto AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
           return _mapper.Map<ReadCinemaDto>(cinema);

        }

       public  List<ReadCinemaDto> RecuperaCinemas([FromQuery] string nomeDoFilme)
       {
                if(nomeDoFilme == null) {
                return null;
            }
            List<Cinema> cinemas = _context.Cinemas.ToList();
         

            if(!string.IsNullOrEmpty(nomeDoFilme)){
                IEnumerable<Cinema> query = from cinema in cinemas 
                where cinema.Sessoes.Any(sessao =>sessao.Filme.Titulo == nomeDoFilme)
                select cinema;
                cinemas = query.ToList();
            }

            return _mapper.Map<List<ReadCinemaDto>>(cinemas);
       }

        public ReadCinemaDto RecuperaCinemasPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if(cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return cinemaDto;
            }
            return null;
        }


    }
}