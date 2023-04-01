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

        public void ObtemCotacaoMoeda(Moeda moeda) // WIP
        {

        }

        public void Imprime() // WIP
        {
            
        }
    }
}
