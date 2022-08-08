using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosApi.Data.Requests
{
    public class EfetuaResetRequest
    {
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
        
        
        
        

    }
}