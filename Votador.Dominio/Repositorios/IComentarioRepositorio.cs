using Votador.Dominio.Entidades;

namespace Votador.Dominio.Repositorios
{
    public interface IComentarioRepositorio
    {
        void Salvar(Comentario comentario);
    }
}