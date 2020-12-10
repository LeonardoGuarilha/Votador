using Microsoft.VisualStudio.TestTools.UnitTesting;
using Votador.Dominio.Entidades;

namespace Votador.Testes.Entidades
{
    [TestClass]
    public class ComentarioTestes
    {
        private readonly Comentario _comentarioValido = new Comentario("Novo comentario", "123", "321");
        private readonly Comentario _comentarioInvalido = new Comentario("", "123", "321");

        [TestMethod]
        public void Deve_criar_um_novo_comentario()
        {
             
            Assert.AreEqual(0, _comentarioValido.Notifications.Count);
        }

        [TestMethod]
        public void Nao_deve_criar_um_comentario_sem_descricao()
        {
            Assert.AreEqual(1, _comentarioInvalido.Notifications.Count); 
        }
        
    }
}