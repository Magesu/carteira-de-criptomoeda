using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carteira_de_criptomoeda
{
    internal class ItemCarteira
    {
        public Moeda moeda { get; set; }
        public double quantidade { get; set; }

        public ItemCarteira() { }

        public ItemCarteira(Moeda moeda, double quantidade)
        {
            this.moeda = moeda;
            this.quantidade = quantidade;
        }

        public double ObtemCotacaoMoeda(Moeda moeda_cotacao) 
        {
            ParMoeda parMoeda = AplicacaoCriptomoedas.parMoedas.Find(r => r.moedaBase == moeda && r.moedaCotacao == moeda_cotacao);
            if(parMoeda != null) 
            {
                return quantidade * parMoeda.valor;
            }
            else
            {
                return -1;
            }
        }

        public void Imprime()
        {
            moeda.Imprime();
            Console.WriteLine("quantidade: {0}", quantidade);
        }
    }
}