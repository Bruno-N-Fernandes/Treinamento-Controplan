using Caixa.Eletronico;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

        [TestMethod]
        public void QuandoSacar30Reais_DeveEntregar2Notas1De10e1De20()
        {
            var caixaEletronico = new CaixaEletronico();

            var notas = caixaEletronico.Sacar(30);

            Assert.IsNotNull(notas);
            Assert.AreEqual(2, notas.Count);
            Assert.IsTrue(notas.Any(n =>n.Valor == 10));
            Assert.IsTrue(notas.Any(n =>n.Valor == 20));
        }

        [TestMethod]
        public void QuandoSacarValorMenorQueAMenorNotaDisponivel_NaoDeveEntregarNotas()
        {
            var caixaEletronico = new CaixaEletronico();
            var menorNota = caixaEletronico.MenorNotaDisponivel;

            for (int i = 0; i < menorNota.Valor; i++)
            {
                var notas = caixaEletronico.Sacar(i);

                Assert.IsNotNull(notas);
                Assert.AreEqual(0, notas.Count, $"Nota {i}");
            }

        }

    }
}
