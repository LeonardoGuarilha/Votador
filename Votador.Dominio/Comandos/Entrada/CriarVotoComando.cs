using System;
using Flunt.Notifications;
using Flunt.Validations;
using Votador.Compartilhado.Comando;

namespace Votador.Dominio.Comandos.Entrada
{
    public class CriarVotoComando : Notifiable, IComando
    {
        public string FuncionarioId { get; set; }
        public string RecursoId { get; set; }
        public string Comentario { get; set; }
        public bool Gostei { get; set; }
        public int QuantidadeVotos { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(FuncionarioId, "Funcionario", "Funcionario não pode ser vazio")
                .IsNotNullOrEmpty(RecursoId, "Recurso", "Recurso não pode ser vazio")
                .IsNotNullOrEmpty(Comentario, "Senha", "Senha não pode ser vazio")
            );
        }
    }
}