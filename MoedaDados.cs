using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carteira_de_criptomoeda
{
    internal class MoedaDados
    {
        public static List<Moeda> moedas = new List<Moeda>();
        public static List<ParMoeda> parMoedas = new List<ParMoeda>();

        public static void AdicionarMoeda(string codigo, string nome)
        {
            Moeda nova_moeda = new Moeda(codigo, nome);
            moedas.Add(nova_moeda);
        }

        public static void RemoverMoeda(Moeda moeda)
        {
            Moeda moeda_a_ser_removida = moedas.SingleOrDefault(r => r == moeda);
            if (moeda_a_ser_removida != null)
            {
               moedas.Remove(moeda_a_ser_removida);
            }
        }

        public static void ImprimeMoedas()
        {
            foreach (Moeda moeda in moedas)
            {
                moeda.Imprime();
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
            if (par_moeda_a_ser_removido != null)
            {
                parMoedas.Remove(par_moeda_a_ser_removido);
            }
        }

        public static void ImprimeParMoedas()
        {
            foreach (ParMoeda parMoeda in parMoedas)
            {
                parMoeda.Imprime();
            }
        }
    }
}
