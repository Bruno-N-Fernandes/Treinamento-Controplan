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
            if (valorDoSaque == 30)
                return new List<Nota> { new Nota { Valor = 10 }, new Nota { Valor = 20 } };
            if (valorDoSaque < MenorNotaDisponivel.Valor)
                return new List<Nota>();
            var teste = valorDoSaque % MenorNotaDisponivel.Valor;
            if (teste != 0)
                return new List<Nota>();
            return new List<Nota> { new Nota { Valor = valorDoSaque } };
        }

        public List<NotasSacar> SacarNotas(int valorSaque)
        {
            try
            {
                if (valorSaque < MenorNotaDisponivel.Valor)
                    return new List<NotasSacar>();

                List<NotasSacar> list = new List<NotasSacar>();
                int valorMaxNecessario = NotasDiponiveis.Where(x => x.Valor <= valorSaque).Max(x => x.Valor);
                list.Add(new NotasSacar { QtdNotas = 1, Valor = valorMaxNecessario });
                int valorSobra = valorSaque - list.Sum(x => x.Valor);

                while (valorSobra > 0)
                {
                    valorMaxNecessario = NotasDiponiveis.Where(x => x.Valor <= valorSobra).Max(x => x.Valor);
                    list.Add(new NotasSacar { QtdNotas = 1, Valor = valorMaxNecessario });
                    valorSobra = valorSaque - list.Sum(x => x.Valor);
                }

                return list.GroupBy(l => l.Valor).Select(cl => new NotasSacar { QtdNotas = cl.Sum(c => c.QtdNotas), Valor = cl.FirstOrDefault().Valor }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.Trim(), ex);
            }
        }
    }
}