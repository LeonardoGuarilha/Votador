using Votador.Dominio.Consultas;
using Votador.Dominio.Entidades;
using Votador.Dominio.Repositorios;

namespace Votador.Testes.RepositoriosFalsos
{
    public class FalsoRepositorioVoto : IVotoRepositorio
    {
        public void Salvar(Voto voto)
        {
            
        }

        public RetornarIdVoto FuncionarioJaVotouNaTarefa(string funcionarioId, string recursoId)
        {
            return null;
        }

        public RetornarRecursoId RecursoJaFoiVotado(string recursoId)
        {
            return null;
        }

        public void AtualizarVotoRecurso(string recursoId)
        {
            
        }
    }
}