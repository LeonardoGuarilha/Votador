using System.Collections.Generic;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Consultas;

namespace Votador.Dominio.Repositorios
{
    public interface IRecuperarRecursosRepository
    {
        IEnumerable<RetornarRecursoConsulta> RecuperarRecursos();
    }
}