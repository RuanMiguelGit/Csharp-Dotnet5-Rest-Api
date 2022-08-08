using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}