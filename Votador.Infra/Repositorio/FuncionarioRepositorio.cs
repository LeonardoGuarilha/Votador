using System.Linq;
using System.Text;
using Dapper;
using Votador.Dominio.Consultas;
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
                    Email = funcionario.Email,
                    Senha = funcionario.Senha
                });
        }

        public RetornarEmailConsultaResultado EmailExiste(string email)
        {
            var query = "SELECT email from funcionario where funcionario .email = @email";
            var retorno = _context.Conexao.
                Query<RetornarEmailConsultaResultado>(query, new {email = email}).FirstOrDefault();

            return retorno;
        }

        public Funcionario UsuarioExiste(string email)
        { 
            var query = "SELECT id, email, senha from funcionario where funcionario.email =@Email";

            var retorno = _context.Conexao.Query<Funcionario>(query, new {Email = email}).FirstOrDefault();

            return retorno;
        }
    }
}