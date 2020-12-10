using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Votador.Compartilhado.Comando;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Comandos.Manipulador;

namespace Votador.Api.Controllers
{
    [Route("v1/autenticar")]
    public class AutenticacaoController : Controller
    {
        private AutenticarComandoManipulador _manipulador;

        public AutenticacaoController(AutenticarComandoManipulador manipulador)
        {
            _manipulador = manipulador;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public IResultadoComando Post([FromBody] AutenticarFuncionarioComando comando)
        {
            var resultado = _manipulador.Manipular(comando);
            return resultado;
        }
        
    }
}