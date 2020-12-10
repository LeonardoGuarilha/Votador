using Microsoft.AspNetCore.Authorization;
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
        private FuncionarioComandoManipulador _manipulador;

        public FuncionarioController(FuncionarioComandoManipulador manipulador)
        {
            _manipulador = manipulador;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public IResultadoComando Post([FromBody] RegistrarFuncionarioComando comando)
        {
            var resultado = _manipulador.Manipular(comando);
            return resultado;
        }

    }
}