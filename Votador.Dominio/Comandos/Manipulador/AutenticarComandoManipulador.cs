using Flunt.Notifications;
using Votador.Compartilhado.Comando;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Comandos.Resultado;
using Votador.Dominio.Repositorios;
using Votador.Dominio.Servico;

namespace Votador.Dominio.Comandos.Manipulador
{
    public class AutenticarComandoManipulador : 
        Notifiable,
        IComandoManipulador<AutenticarFuncionarioComando>
    {
        
        private readonly IFuncionarioRepositorio _repositorio;

        public AutenticarComandoManipulador(IFuncionarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        
        public IResultadoComando Manipular(AutenticarFuncionarioComando comando)
        {
            var usuario = _repositorio.UsuarioExiste(comando.Email);
            
            if (usuario == null)
            {
                AddNotification("Email", "Ocorreu um erro na autenticação");
                
                return new ResultadoComando(
                    false, 
                    "Ocorreu um erro na autenticação", 
                    new {mensagem = "Usuário não existe"});
            }

            if (usuario.Autenticar(comando.Email, comando.Senha))
            {
                return new ResultadoComando(
                    true, 
                    "Logado com sucesso", 
                    new {Usuario = usuario, Token = ServicoToken.GerarToken(usuario)});
                // Verificar no frontend a necessidade de retornar o usuario completo
            }
            else
            {
                AddNotification("Email", "Ocorreu um erro na autenticação");
                
                return new ResultadoComando(
                    false, 
                    "Ocorreu um erro na autenticação", 
                    new {erro = comando.Notifications});
            }
        }
    }
}