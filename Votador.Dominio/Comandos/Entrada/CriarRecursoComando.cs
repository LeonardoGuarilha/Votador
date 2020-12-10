using Votador.Compartilhado.Comando;

namespace Votador.Dominio.Comandos.Entrada
{
    public class CriarRecursoComando : IComando
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}