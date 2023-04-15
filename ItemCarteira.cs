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
        public List<ParMoeda> parMoedas;

        public ItemCarteira() 
        {
            this.parMoedas = new List<ParMoeda>();
        }

        public ItemCarteira(Moeda moeda, double quantidade)
        {
            this.moeda = moeda;
            this.quantidade = quantidade;
            this.parMoedas = new List<ParMoeda>();
        }

        public double ObtemCotacaoMoeda(Moeda moeda) // WIP
        {
            ParMoeda parMoeda = parMoedas.Find
                (
                    delegate (ParMoeda pm)
                    {
                        return pm.moedaCotacao == moeda;
                    }
                );
            return quantidade * parMoeda.valor;
        }

        public void Imprime()
        {
            moeda.Imprime();
            Console.WriteLine("quantidade: {0}", quantidade);
            foreach(ParMoeda parMoeda in parMoedas)
            {
                parMoeda.Imprime();
            }
        }
    }
}
