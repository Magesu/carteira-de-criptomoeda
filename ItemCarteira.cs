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
        public static List<ParMoeda> parMoedas;

        public ItemCarteira() 
        {
            parMoedas = new List<ParMoeda>();
        }

        public ItemCarteira(Moeda moeda, double quantidade)
        {
            this.moeda = moeda;
            this.quantidade = quantidade;
            parMoedas = new List<ParMoeda>();
        }

        public double ObtemCotacaoMoeda(Moeda moeda) 
        {
            ParMoeda parMoeda = parMoedas.SingleOrDefault(r => r.moedaCotacao == moeda);
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

        public static void ImprimeParMoedas()
        {
            foreach (ParMoeda parMoeda in parMoedas)
            {
                parMoeda.Imprime();
            }
        }

        public void AdicionarParMoeda(Moeda moeda_cotacao, double valor)
        {
            ParMoeda novo_par_moeda = new ParMoeda(this.moeda, moeda_cotacao, valor);
            parMoedas.Add(novo_par_moeda);
        }
    }
}