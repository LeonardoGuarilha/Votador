using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Votador.Compartilhado.Comando;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Comandos.Manipulador;

namespace Votador.Api.Controllers
{
    [Route("v1/recurso")]
    public class RecursoController : Controller
    {
        private CriarRecursoManipulador _manipulador;

        public RecursoController(CriarRecursoManipulador manipulador)
        {
            _manipulador = manipulador;
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public IResultadoComando Post([FromBody] CriarRecursoComando comando)
        {
            var resultado = _manipulador.Manipular(comando);
            return resultado;
        }

    }
}