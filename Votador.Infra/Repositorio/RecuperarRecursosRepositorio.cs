using System.Collections.Generic;
using System.Text;
using Dapper;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Consultas;
using Votador.Dominio.Repositorios;
using Votador.Infra.DataContext;

namespace Votador.Infra.Repositorio
{
    public class RecuperarRecursosRepositorio : IRecuperarRecursosRepository
    {
        private readonly VotadorDataContext _context;

        public RecuperarRecursosRepositorio(VotadorDataContext context)
        {
            _context = context;
        }
        
        public IEnumerable<RetornarRecursoConsulta> RecuperarRecursos()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(@"select r.titulo , v.quantidadevotos from recurso r ");
            stringBuilder.Append(@"left join voto v on v.recursoid = r.id ");

            return  _context.Conexao.Query<RetornarRecursoConsulta>(stringBuilder.ToString());
        }
    }
}