using Votador.Dominio.Consultas;
using Votador.Dominio.Entidades;
using Votador.Dominio.Repositorios;

namespace Votador.Testes.RepositoriosFalsos
{
    public class FalsoRepositorioFuncionario : IFuncionarioRepositorio
    {
        public void Salvar(Funcionario funcionario)
        {
            
        }

        public RetornarEmailConsultaResultado EmailExiste(string email)
        {
            return null;
        }

        public Funcionario UsuarioExiste(string email)
        {
            var funcionario = new Funcionario("Leonardo", "email@email.com", "123456");
            return funcionario;
        }
    }
}