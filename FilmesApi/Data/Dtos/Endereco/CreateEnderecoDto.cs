﻿using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class CreateEnderecoDto
    {
       [Key]
        [Required]
        public int id {get; set;}
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int numero { get; set; }
    }
}