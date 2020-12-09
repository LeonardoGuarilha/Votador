using Microsoft.AspNetCore.Mvc;
using Votador.Compartilhado.Comando;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Comandos.Manipulador;
using Votador.Dominio.Repositorios;

namespace Votador.Api.Controllers
{
    [Route("v1/funcionario")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepositorio _repositorio;
        private FuncionarioComandoManipulador _manipulador;

        public FuncionarioController(IFuncionarioRepositorio repositorio, FuncionarioComandoManipulador manipulador)
        {
            _repositorio = repositorio;
            _manipulador = manipulador;
        }

        [HttpPost]
        [Route("")]
        public IResultadoComando Post([FromBody] RegistrarFuncionarioComando comando)
        {
            var resultado = _manipulador.Manipular(comando);
            return resultado;
        }

    }
}