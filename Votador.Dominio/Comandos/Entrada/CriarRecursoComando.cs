using Flunt.Notifications;
using Flunt.Validations;
using Votador.Compartilhado.Comando;

namespace Votador.Dominio.Comandos.Entrada
{
    public class CriarRecursoComando : Notifiable, IComando
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Titulo, "Titulo", "Titulo não pode ser vazio")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Descricao não pode ser vazia")
            );
        }
    }
}