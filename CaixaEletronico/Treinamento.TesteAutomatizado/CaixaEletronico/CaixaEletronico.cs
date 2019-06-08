using System;
using System.Collections.Generic;

namespace Caixa.Eletronico
{
    public class CaixaEletronico
    {
        public CaixaEletronico()
        {
        }

        public List<Notas> Sacar(int valorDoSaque)
        {

            return new List<Notas> { new Notas { Valor = valorDoSaque } };
        }
    }
}