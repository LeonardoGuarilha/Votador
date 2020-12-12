using Flunt.Notifications;
using Votador.Compartilhado.Comando;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Comandos.Resultado;
using Votador.Dominio.Entidades;
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
            var emailExiste = _repositorio.EmailExiste(comando.Email);
            
            if (emailExiste != null)
            {
                AddNotification("Email", "Email já está cadastrado");
                
                return new ResultadoComando(
                    false, 
                    "Ocorreu um erro ao salvar o funcionário", 
                    new {});
            }
            
            var funcionario = new Funcionario(comando.Nome, comando.Email, comando.Senha);

            AddNotifications(funcionario.Notifications);
            
            if(!Invalid)
                _repositorio.Salvar(funcionario);
            else
            {
                return new ResultadoComando(false, "Ocorreu um erro ao salvar o funcionário", new {funcionario.Notifications});
            }

            return new ResultadoComando(
                true, 
                "Funcionário cadastrado com sucesso!", 
                new { email = funcionario.Email });
        }
    }
}