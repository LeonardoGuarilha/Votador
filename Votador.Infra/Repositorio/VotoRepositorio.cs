using System.Linq;
using Dapper;
using Votador.Dominio.Consultas;
using Votador.Dominio.Entidades;
using Votador.Dominio.Repositorios;
using Votador.Infra.DataContext;

namespace Votador.Infra.Repositorio
{
    public class VotoRepositorio : IVotoRepositorio
    {
        private readonly VotadorDataContext _context;

        public VotoRepositorio(VotadorDataContext context)
        {
            _context = context;
        }
        public void Salvar(Voto voto)
        {
            var query =
                @"INSERT INTO voto(id, funcionarioId, recursoId, horavoto, gostei, quantidadevotos) values (@id, @funcionarioId, @recursoId, @horavoto, @gostei, @quantidadevotos)";
            _context.Conexao.Execute(query,
                new
                {
                    Id = voto.Id,
                    FuncionarioId = voto.FuncionarioId,
                    RecursoId = voto.RecursoId,
                    HoraVoto = voto.HoraVoto,
                    Gostei = voto.Gostei,
                    QuantidadeVotos = voto.QuantidadeVotos
                });
        }

        public RetornarIdVoto FuncionarioJaVotouNaTarefa(string funcionarioId, string recursoId)
        {
            var query = @"SELECT id FROM voto WHERE funcionarioId = @funcionarioId and recursoId = @recursoId";
            
            return _context.Conexao.Query<RetornarIdVoto>(query, new {FuncionarioId = funcionarioId, RecursoId = recursoId}).FirstOrDefault();
            
        }

        public RetornarRecursoId RecursoJaFoiVotado(string recursoId)
        {
            var query = @"SELECT id FROM voto WHERE recursoId = @recursoId";
            
            return _context.Conexao.Query<RetornarRecursoId>(query, new {RecursoId = recursoId}).FirstOrDefault();

        }

        public void AtualizarVotoRecurso(string recursoId)
        {
            var query = @"UPDATE voto set QuantidadeVotos = QuantidadeVotos + 1 WHERE recursoId = @recursoId";

            _context.Conexao.Execute(query, new {RecursoId = recursoId});
        }
    }
}