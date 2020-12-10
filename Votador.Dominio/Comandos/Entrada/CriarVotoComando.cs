using System;
using Votador.Compartilhado.Comando;

namespace Votador.Dominio.Comandos.Entrada
{
    public class CriarVotoComando : IComando
    {
        public string FuncionarioId { get; set; }
        public string RecursoId { get; set; }
        public string Comentario { get; set; }
        public bool Gostei { get; set; }
        public int QuantidadeVotos { get; set; }
    }
}