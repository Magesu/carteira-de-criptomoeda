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
            moedaBase.Imprime();
            moedaCotacao.Imprime();
            Console.WriteLine("valor: {0:0.00}", valor);
        }
    }
}
