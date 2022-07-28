using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FilmesAPI.Models;

namespace FilmesAPI.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }
        // public int EnderecoFK { get; set; }
        // public int GerenteFK { get; set; }
        // public virtual Endereco Endereco { get; set; }
        // public int EnderecoId { get; set; }
        [JsonIgnore]
        public virtual List<Cinema> Cinemas { get; set; }
        
        
    }
}