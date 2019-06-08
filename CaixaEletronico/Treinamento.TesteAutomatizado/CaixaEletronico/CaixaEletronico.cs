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
            switch (valorDoSaque)
            {
                case 10:
                    return new List<Nota> { new Nota { Valor = valorDoSaque } };
                case 20:
                    return new List<Nota> { new Nota { Valor = valorDoSaque } };
                case 50:
                    return new List<Nota> { new Nota { Valor = valorDoSaque } };
                case 100:
                    return new List<Nota> { new Nota { Valor = valorDoSaque } };
                default:
                    return VerificaRetornoNota(valorDoSaque);                    
            }             
            
        }

        private List<Nota> VerificaRetornoNota(int valorDoSaque)
        {            
            if (valorDoSaque < MenorNotaDisponivel.Valor)
                return new List<Nota>();
            var teste = valorDoSaque % MenorNotaDisponivel.Valor;
            if (teste != 0)
                return new List<Nota>();

            List <Nota> listaNotaAux = NotasDiponiveis.Where(x => x.Valor < valorDoSaque).ToList();
            int vlSaque = 0;
            List<Nota> notaRetorno = new List<Nota>();
            while (vlSaque != valorDoSaque)
            {
                Nota ntAux = new Nota();
                if (vlSaque == 0)
                {
                    vlSaque = listaNotaAux.LastOrDefault().Valor;
                    ntAux.Valor = vlSaque;
                    notaRetorno.Add(ntAux);
                }
                else
                {
                    int vlSaqueAux = listaNotaAux.LastOrDefault(x => x.Valor <= (valorDoSaque - vlSaque)).Valor;
                    vlSaque += vlSaqueAux;
                    ntAux.Valor = vlSaqueAux;
                    notaRetorno.Add(ntAux);
                }
            }
           
            //if (valorDoSaque == 30)
              //  return new List<Nota> { new Nota { Valor = 10 }, new Nota { Valor = 20 } };

            return notaRetorno;


        }


    }

    
}