using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace FilmesApi.Authorization
{
   public class IdadeMinimaRequirements : IAuthorizationRequirement
    {
        public int IdadeMinima { get; set; }

        public  IdadeMinimaRequirements(int idadeMinima)
        {
            IdadeMinima = idadeMinima;
        }
    }
}