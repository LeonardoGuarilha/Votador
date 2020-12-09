using Votador.Compartilhado.Comando;

namespace Votador.Dominio.Comandos.Entrada
{
    public class RegistrarFuncionarioComando : IComando
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}