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



    }
}