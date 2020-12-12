using System;
using Flunt.Validations;
using Votador.Compartilhado.Entidades;

namespace Votador.Dominio.Entidades
{
    public class Voto : Entidade
    {
        public Voto(string funcionarioId, string tarefaId, bool gostei)
        {
            FuncionarioId = funcionarioId;
            RecursoId = tarefaId;
            HoraVoto = DateTime.Now;
            Gostei = gostei;
            QuantidadeVotos = 1;
            
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(FuncionarioId, "FuncionarioId", "É necessário um funcionário para realizar o voto")
                .IsNotNullOrEmpty(RecursoId, "RecursoId", "É necessário um recurso para realizar o voto")
            );
        }
        
        public string FuncionarioId { get; private set; }
        public string RecursoId { get; private set; }
        public DateTime HoraVoto { get; private set; }
        public bool Gostei { get; set; }
        public int QuantidadeVotos { get; private set; }
    
    }
}