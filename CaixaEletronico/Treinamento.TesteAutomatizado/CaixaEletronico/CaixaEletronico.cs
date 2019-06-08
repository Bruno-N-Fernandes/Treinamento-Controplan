using System;
using System.Collections.Generic;
using System.Linq;

namespace Caixa.Eletronico
{
    public class CaixaEletronico
    {
        public List<Nota> NotasDiponiveis { get; set; }
        public Nota MenorNotaDisponivel => NotasDiponiveis.FirstOrDefault(n => n.Valor == NotasDiponiveis.Min(x => x.Valor));

        public CaixaEletronico()
        {
            NotasDiponiveis = new List<Nota>
            {
                new Nota { Valor = 10 },
                new Nota { Valor = 20 },
                new Nota { Valor = 50 },
                new Nota { Valor = 100 }
            };
        }

        public List<Nota> Sacar(int valorDoSaque)
        {
			var valorRestante = valorDoSaque;
			var notasRetornadas = new List<Nota>();
			var notasElegiveis = NotasDiponiveis.Where(x => x.Valor <= valorRestante);
			var maiorValor = notasElegiveis.Any()? notasElegiveis.Max(x => x.Valor) : MenorNotaDisponivel.Valor;

			while ((valorRestante > 0) && (valorRestante >= maiorValor))
			{
				var nota = NotasDiponiveis.FirstOrDefault(n => n.Valor == maiorValor);
				notasRetornadas.Add(nota);
				valorRestante -= nota.Valor;

				if (valorRestante > 0)
				{
					notasElegiveis = NotasDiponiveis.Where(x => x.Valor <= valorRestante);
					maiorValor = notasElegiveis.Any() ? notasElegiveis.Max(x => x.Valor) : 0;
				}
			}

			return notasRetornadas;
        }
    }

    
}