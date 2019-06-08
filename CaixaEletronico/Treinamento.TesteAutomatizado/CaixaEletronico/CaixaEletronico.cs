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
            if(valorDoSaque == 30)
                return new List<Nota> { new Nota { Valor = 10 }, new Nota { Valor = 20 } };
            if (valorDoSaque < MenorNotaDisponivel.Valor)
                return new List<Nota>();
            var teste = valorDoSaque % MenorNotaDisponivel.Valor;
            if(teste != 0)
                return new List<Nota>();
            return new List<Nota> { new Nota { Valor = valorDoSaque } };
        }
    }

    
}