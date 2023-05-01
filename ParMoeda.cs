using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carteira_de_criptomoeda
{
    internal class ParMoeda
    {
        public Moeda moedaBase { get; set; }
        public Moeda moedaCotacao { get; set; }
        public double valor { get; set; }

        public ParMoeda() { }

        public ParMoeda(Moeda moedaBase, Moeda moedaCotacao, double valor)
        {
            this.moedaBase = moedaBase;
            this.moedaCotacao = moedaCotacao;
            this.valor = valor;
        }

        public void Imprime()
        {
            Console.Write("Moeda: {0}\tPar: {1}/{2}\tValor: {3:0.00}", moedaBase.Nome, moedaBase.Codigo, moedaCotacao.Codigo, valor);
        }
    }
}