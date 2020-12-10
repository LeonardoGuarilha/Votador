using Dapper;
using Votador.Dominio.Entidades;
using Votador.Dominio.Repositorios;
using Votador.Infra.DataContext;

namespace Votador.Infra.Repositorio
{
    public class RecursoRepositorio : IRecursoRepositorio
    {
        private readonly VotadorDataContext _context;

        public RecursoRepositorio(VotadorDataContext context)
        {
            _context = context;
        }
        
        public void Salvar(Recurso recurso)
        {
            var query = "INSERT INTO recurso (id, titulo, descricao) values (@id, @titulo, @descricao)";
            _context.Conexao.Execute(query,
                new
                {
                    Id = recurso.Id,
                    Titulo = recurso.Titulo,
                    Descricao = recurso.Descricao
                });
        }
    }
}