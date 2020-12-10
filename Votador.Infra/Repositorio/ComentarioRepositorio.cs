using Dapper;
using Votador.Dominio.Entidades;
using Votador.Dominio.Repositorios;
using Votador.Infra.DataContext;

namespace Votador.Infra.Repositorio
{
    public class ComentarioRepositorio : IComentarioRepositorio
    {
        private readonly VotadorDataContext _context;

        public ComentarioRepositorio(VotadorDataContext context)
        {
            _context = context;
        }

        public void Salvar(Comentario comentario)
        {
            var query = @"INSERT INTO comentario(id, descricao, recursoId, funcionarioId, datavoto) values (@id, @descricao, @recursoId, @funcionarioId, @DataVoto)";

            _context.Conexao.Execute(query,
                new
                {
                    Id = comentario.Id,
                    Descricao = comentario.Descricao,
                    RecursoId = comentario.RecursoId,
                    FuncionarioID = comentario.FuncionarioId,
                    DataVoto = comentario.DataVoto
                });
        }
    }
}