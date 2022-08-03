using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentResults;
using UsuariosApi.Services;



namespace UsuariosApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        private LogoutService _logoutService;
        public LogoutController(LogoutService logoutService)
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogaUsuario()
        {
            Result result =  _logoutService.DeslogaUsuario();
            if(result.IsFailed) return Unauthorized(result.Errors);
            return Ok(result.Successes);
        }
    }
}