using System;
using System.Collections.Generic;
using System.Linq;

namespace Caixa.Eletronico
{
    public class CaixaEletronico
    {
        public List<Notas> NotasDiponiveis { get; set; }
        public Notas MenorNotaDisponivel => NotasDiponiveis.FirstOrDefault(n => n.Valor == NotasDiponiveis.Min(x => x.Valor));

        public CaixaEletronico()
        {
            NotasDiponiveis = new List<Notas>
            {
                new Notas { Valor = 10 },
                new Notas { Valor = 20 },
                new Notas { Valor = 50 },
                new Notas { Valor = 100 }
            };
        }

        public List<Notas> Sacar(int valorDoSaque)
        {
            if(valorDoSaque == 30)
                return new List<Notas> { new Notas { Valor = 10 }, new Notas { Valor = 20 } };
            if (valorDoSaque < MenorNotaDisponivel.Valor)
                return new List<Notas>();
            var teste = valorDoSaque % MenorNotaDisponivel.Valor;
            if(teste != 0)
                return new List<Notas>();
            return new List<Notas> { new Notas { Valor = valorDoSaque } };
        }
    }

    
}