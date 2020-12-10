using Microsoft.VisualStudio.TestTools.UnitTesting;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Comandos.Manipulador;
using Votador.Dominio.Entidades;
using Votador.Testes.RepositoriosFalsos;

namespace Votador.Testes.Manipuladores
{
    [TestClass]
    public class FuncionarioComandoManipuladorTeste
    {
        private readonly RegistrarFuncionarioComando _comandoValido = new RegistrarFuncionarioComando();
        private readonly RegistrarFuncionarioComando _comandoInvalido = new RegistrarFuncionarioComando();

        public FuncionarioComandoManipuladorTeste()
        {
            _comandoValido.Nome = "Leonardo";
            _comandoValido.Email = "leonardo@email.com";
            _comandoValido.Senha = "123456";
            
            _comandoInvalido.Nome = "Leonardo";
            _comandoInvalido.Email = "leonardo@email.com";
            _comandoInvalido.Senha = "";
        }
            
        [TestMethod]
        public void Deve_cadastrar_um_funcionario_caso_informacoes_corretas()
        {
            var manipulador = new FuncionarioComandoManipulador(new FalsoRepositorioFuncionario());
            var resultado = manipulador.Manipular(_comandoValido);
            
            _comandoValido.Validar();
            
            Assert.AreNotEqual(null, resultado);
            Assert.AreEqual(true, manipulador.Valid);
            Assert.AreEqual(true, _comandoValido.Valid);
        }

        [TestMethod]
        public void Nao_deve_cadastrar_funcionario_caso_a_senha_nao_esteja_preenchida()
        {
            var manipulador = new FuncionarioComandoManipulador(new FalsoRepositorioFuncionario());
            var resultado = manipulador.Manipular(_comandoInvalido);
            
            _comandoInvalido.Validar();
            
            Assert.IsFalse(_comandoInvalido.Valid);
            Assert.AreNotEqual(null, resultado);
        }
    }
}