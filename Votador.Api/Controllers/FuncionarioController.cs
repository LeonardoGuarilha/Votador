using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Votador.Compartilhado.Comando;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Comandos.Manipulador;
using Votador.Dominio.Consultas;
using Votador.Dominio.Repositorios;

namespace Votador.Api.Controllers
{
    [Route("v1/funcionario")]
    public class FuncionarioController : Controller
    {
        private FuncionarioComandoManipulador _manipulador;
        private IFuncionarioRepositorio _repositorio;

        public FuncionarioController(FuncionarioComandoManipulador manipulador, IFuncionarioRepositorio repositorio)
        {
            _manipulador = manipulador;
            _repositorio = repositorio;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public IResultadoComando Post([FromBody] RegistrarFuncionarioComando comando)
        {
            var resultado = _manipulador.Manipular(comando);
            return resultado;
        }
        
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public IEnumerable<RetornarFuncionarioConsulta> Get()
        {
            return _repositorio.RetornarUsuarios();
        }

    }
}