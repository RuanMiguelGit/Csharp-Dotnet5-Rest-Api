using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace FilmesApi.Authorization
{
    public class IdadeMinimaHandler : AuthorizationHandler<IdadeMinimaRequirements>
    {
         protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            IdadeMinimaRequirements requirement)
        {
            if(!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth)) return Task.CompletedTask;
            

            DateTime dataDeNascimento = Convert.ToDateTime(context.User.FindFirst(c => 
                c.Type == ClaimTypes.DateOfBirth
            ).Value);

            int idadeObtida = DateTime.Today.Year - dataDeNascimento.Year;

            if(dataDeNascimento > DateTime.Today.AddYears(-idadeObtida) )
            idadeObtida--;

            if(idadeObtida >= requirement.IdadeMinima)  context.Succeed(requirement);
             return Task.CompletedTask;
        }
    }
}