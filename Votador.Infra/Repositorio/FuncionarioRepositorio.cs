using System.Linq;
using Dapper;
using Votador.Dominio.Entidades;
using Votador.Dominio.Repositorios;
using Votador.Infra.DataContext;

namespace Votador.Infra.Repositorio
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {

        private readonly VotadorDataContext _context;

        public FuncionarioRepositorio(VotadorDataContext context)
        {
            _context = context;
        }
        public void Salvar(Funcionario funcionario)
        {
            var query = "INSERT INTO funcionario (id, email, senha) values (@id, @email, @senha)";
            _context.Conexao.Execute(query,
                new
                {
                    Id = funcionario.Id,
                    Email = funcionario.Email.Endereco,
                    Senha = funcionario.Senha
                });
        }

        public bool EmailExiste(string email)
        {
            var query = "SELECT email from funcionario where email = @email";

            return _context.Conexao.Query<bool>(query, new { email = email }).Any();
        }
    }
}