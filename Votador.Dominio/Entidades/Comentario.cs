using System;
using Flunt.Validations;
using Votador.Compartilhado.Entidades;

namespace Votador.Dominio.Entidades
{
    public class Comentario : Entidade
    {
        public Comentario(string descricao, string recursoId, string funcionarioId)
        {
            Descricao = descricao;
            RecursoId = recursoId;
            DataVoto = DateTime.Now;
            FuncionarioId = funcionarioId;
            
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Descricao, "Descricao", "A descrição precisa estar preenchida")
                .IsNotNullOrEmpty(RecursoId, "RecursoId", "O recurso precisa ser informado")
            );
        }
        
        public string Descricao { get; private set; }
        public string RecursoId { get; private set; }
        public string FuncionarioId { get; private set; }
        public DateTime DataVoto { get; private set; }
        
    }
}