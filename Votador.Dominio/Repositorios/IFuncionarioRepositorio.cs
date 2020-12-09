using Votador.Dominio.Entidades;

namespace Votador.Dominio.Repositorios
{
    public interface IFuncionarioRepositorio
    {
        void Salvar(Funcionario funcionario);
        bool EmailExiste(string email);
    }
}