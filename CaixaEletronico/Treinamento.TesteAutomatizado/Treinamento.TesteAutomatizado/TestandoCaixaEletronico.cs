using Caixa.Eletronico;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Treinamento.TesteAutomatizado
{
    [TestClass]
    public class TestandoCaixaEletronico
    {
        [TestMethod]
        public void QuandoSacar100Reais_DeveEntregar1Notade100()
        {
            var caixaEletronico = new CaixaEletronico();

            var notas = caixaEletronico.Sacar(100);

            Assert.IsNotNull(notas);
            Assert.AreEqual(1, notas.Count);
            Assert.AreEqual(100, notas[0].Valor);
        }
        [TestMethod]
        public void QuandoSacar50Reais_DeveEntregar1Notade50()
        {
            var caixaEletronico = new CaixaEletronico();

            var notas = caixaEletronico.Sacar(50);

            Assert.IsNotNull(notas);
            Assert.AreEqual(1, notas.Count);
            Assert.AreEqual(50, notas[0].Valor);
        }


    }
}
