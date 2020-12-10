using Flunt.Notifications;
using Flunt.Validations;
using Votador.Compartilhado.Comando;

namespace Votador.Dominio.Comandos.Entrada
{
    public class AutenticarFuncionarioComando : Notifiable, IComando
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Email, "Email", "E-mail não pode ser vazio")
                .IsNotNullOrEmpty(Senha, "Senha", "Senha não pode ser vazio")
            );
        }
    }
}