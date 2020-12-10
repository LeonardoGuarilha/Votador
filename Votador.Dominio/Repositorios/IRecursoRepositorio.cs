using Votador.Dominio.Entidades;

namespace Votador.Dominio.Repositorios
{
    public interface IRecursoRepositorio
    {
        void Salvar(Recurso recurso);
    }
}