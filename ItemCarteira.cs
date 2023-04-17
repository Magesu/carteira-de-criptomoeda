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

        public static void AdicionarParMoeda(Moeda moeda_base, Moeda moeda_cotacao, double valor)
        {
            ParMoeda novo_par_moeda = new ParMoeda(moeda_base, moeda_cotacao, valor);
            parMoedas.Add(novo_par_moeda);
        }

        public static void RemoverParMoeda(Moeda moeda_base, Moeda moeda_cotacao)
        {
            ParMoeda par_moeda_a_ser_removido = parMoedas.SingleOrDefault(r => r.moedaBase == moeda_base && r.moedaCotacao == moeda_cotacao);
            if(par_moeda_a_ser_removido != null)
            {
                parMoedas.Remove(par_moeda_a_ser_removido);
            }
        }
    }
}