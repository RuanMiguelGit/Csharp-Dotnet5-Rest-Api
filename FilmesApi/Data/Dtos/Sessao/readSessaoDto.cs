using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class readSessaoDto
    {
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public int Id  {get; set;}   
        public DateTime HorarioDeInicio {get; set;}
        // public int EnderecoFK { get; set; }
        // public int GerenteFK { get; set; }
    }
}
