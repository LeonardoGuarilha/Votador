using System.Text;
using Flunt.Validations;
using Votador.Compartilhado.Entidades;
using Votador.Dominio.ObjetoValor;

namespace Votador.Dominio.Entidades
{
    public class Funcionario : Entidade
    {
        public Funcionario(Email email, string senha)
        {
            Email = email;
            Senha = HashSenha(senha);

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Email.Endereco, "Email", "E-mail não pode ser vazio")
                .IsNotNullOrEmpty(Senha, "Senha", "A senha não pode ser vazia")
            );
        }
        public Email Email { get; private set; }
        public string Senha { get; private set; }

        public bool Autenticar(string email, string senha)
        {
            if (Email.Endereco == email && Senha == HashSenha(senha)) // Qualquer coisa, retirar o ValueObject
                return true;

            AddNotification("User", "Usuário ou senha inválidos");
            return false;
        }

        private string HashSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha)) return "";
            var password = (senha += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}