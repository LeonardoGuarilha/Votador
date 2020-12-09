using Flunt.Notifications;
using Flunt.Validations;

namespace Votador.Dominio.ObjetoValor
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Endereco = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Endereco, "Endereco", "E-mail inválido")
            );
        }

        public string Endereco { get; private set; }
    }
}