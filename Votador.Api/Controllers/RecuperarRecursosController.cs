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
        private readonly IRecuperarRecursosRepository _repositorio;

        public RecuperarRecursosController(IRecuperarRecursosRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public IEnumerable<RetornarRecursoConsulta> Get()
        {
            return _repositorio.RecuperarRecursos();
        }
    }
}