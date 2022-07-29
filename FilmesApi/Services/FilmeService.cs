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
    public class FilmeService : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
             Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperaFilmes([FromQuery] int xablau)
        {
             List<Filme> filmes = _context.Filmes.Where(f=> f.Duracao <= xablau).ToList();

            if(filmes != null) {
                List<ReadFilmeDto> dto = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return dto;
            }

            return null;
        }

        public ReadFilmeDto RecuperaFilmesPorId(int id)
        {
             Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
               if(filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

                return filmeDto;
            }
            return null;
        }

        // public ReadFilmeDto AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        // {
        //     Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        //     if(filme == null){
        //         return NotFound();
        //     }

        //     _mapper.Map(filmeDto, filme);
        //     _context.SaveChanges();
        //     return null;
        // }

        // public ReadFilmeDto DeletaFilme(int id)
        // {
        //       Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        //     if(filme == null){
        //         return NotFound();
        //     }
        //     _context.Remove(filme);
        //     _context.SaveChanges();
        //     return null;
        // }


    }
}