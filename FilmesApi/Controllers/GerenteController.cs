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

namespace FilmesApi.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    [ApiController]
    public class GerenteController : ControllerBase
    {

        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context =  context;
            _mapper = mapper;
        }

       
        [HttpPost]
        public IActionResult AddManager([FromBody] CreateGerenteDto addManger )
        {
            Gerente gerente = _mapper.Map<Gerente>(addManger);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = gerente.Id }, gerente);

        }

        [HttpGet]
        public IActionResult RecuperaGerentesPorId(int id)
        {
               Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
               if(gerente != null)
            {
                ReadGerenteDto GerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

                return Ok(GerenteDto);
            }
            return NotFound();
        }
    }

}