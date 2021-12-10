using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UsuarioAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public dynamic Get()
        {
            return new 
            {
                Mensagem = "Bem vindo a API do desafio 21 dias multiplas APIs",
                Documentacao = $"/swagger/index.html"
            };
        }
    }
}
