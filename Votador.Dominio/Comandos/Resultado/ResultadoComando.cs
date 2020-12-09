using Votador.Compartilhado.Comando;

namespace Votador.Dominio.Comandos.Resultado
{
    public class ResultadoComando : IResultadoComando
    {
        public ResultadoComando(bool sucesso, string mensagem, object dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }
        
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }
    }
}