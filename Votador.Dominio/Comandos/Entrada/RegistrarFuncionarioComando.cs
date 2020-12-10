using Flunt.Notifications;
using Flunt.Validations;
using Votador.Compartilhado.Comando;

namespace Votador.Dominio.Comandos.Entrada
{
    public class RegistrarFuncionarioComando : Notifiable, IComando
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome, "Nome", "Nome não pode ser vazio")
                .IsNotNullOrEmpty(Email, "Email", "E-mail não pode ser vazio")
                .IsNotNullOrEmpty(Senha, "Senha", "Senha não pode ser vazio")
            );
        }
    }
}