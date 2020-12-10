using Flunt.Validations;
using Votador.Compartilhado.Entidades;

namespace Votador.Dominio.Entidades
{
    public class Recurso : Entidade
    {
        public Recurso(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
            
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Titulo, "Titulo", "O título não pode ser vazio")
                .IsNotNullOrEmpty(Descricao, "Descricao", "A descrição não pode ser vazia")
            );
        }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
    }
}