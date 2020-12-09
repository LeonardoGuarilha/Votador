using Flunt.Notifications;
using Votador.Compartilhado.Comando;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Comandos.Resultado;
using Votador.Dominio.Entidades;
using Votador.Dominio.ObjetoValor;
using Votador.Dominio.Repositorios;

namespace Votador.Dominio.Comandos.Manipulador
{
    public class FuncionarioComandoManipulador : 
        Notifiable,
        IComandoManipulador<RegistrarFuncionarioComando>
    {
        private readonly IFuncionarioRepositorio _repositorio;

        public FuncionarioComandoManipulador(IFuncionarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IResultadoComando Manipular(RegistrarFuncionarioComando comando)
        {
            if (_repositorio.EmailExiste(comando.Email))
                AddNotification("Email", "Email já está cadastrado");
            
            var email = new Email(comando.Email);
            var funcionario = new Funcionario(email, comando.Senha);

            AddNotifications(email.Notifications);
            
            if(!Invalid)
                _repositorio.Salvar(funcionario);
            else
            {
                return new ResultadoComando(false, "Ocorreu um erro ao salvar o funcionário", new {comando.Email});
            }

            return new ResultadoComando(
                true, 
                "Funcionário cadastrado com sucesso!", 
                new { email = funcionario.Email.Endereco });
        }
    }
}