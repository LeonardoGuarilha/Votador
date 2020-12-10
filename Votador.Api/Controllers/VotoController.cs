using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Votador.Compartilhado.Comando;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Comandos.Manipulador;

namespace Votador.Api.Controllers
{
    [Route("v1/voto")]
    public class VotoController : Controller
    {
        private readonly CriarVotoManipulador _manipulador;

        public VotoController(CriarVotoManipulador manipulador)
        {
            _manipulador = manipulador;
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public IResultadoComando Post([FromBody] CriarVotoComando comando)
        {
            var resultado = _manipulador.Manipular(comando);
            return resultado;
        }
    }
}