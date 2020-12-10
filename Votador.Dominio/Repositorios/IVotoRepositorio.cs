using Votador.Dominio.Consultas;
using Votador.Dominio.Entidades;

namespace Votador.Dominio.Repositorios
{
    public interface IVotoRepositorio
    {
        void Salvar(Voto voto);
        RetornarIdVoto FuncionarioJaVotouNaTarefa(string funcionarioId, string recursoId);
        RetornarRecursoId RecursoJaFoiVotado(string recursoId);
        void AtualizarVotoRecurso(string recursoId);
        
    }
}