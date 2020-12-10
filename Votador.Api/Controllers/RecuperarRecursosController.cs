using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Votador.Dominio.Consultas;
using Votador.Dominio.Repositorios;

namespace Votador.Api.Controllers
{
    [Route("v1/recursos")]
    public class RecuperarRecursosController : Controller
    {
        private readonly IRecuperarRecursosRepository _repository;

        public RecuperarRecursosController(IRecuperarRecursosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public IEnumerable<RetornarRecursoConsulta> Get()
        {
            return _repository.RecuperarRecursos();
        }
        
    }
}