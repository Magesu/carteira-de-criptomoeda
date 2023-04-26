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

        public static void ImprimeMoedas()
        {
            foreach (Moeda moeda in moedas)
            {
                moeda.Imprime();
            }
        }

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

        public static void AdicionarParMoeda()
        {
            String codigo_moeda_base;
            String codigo_moeda_cotacao;
            Moeda moeda_base;
            Moeda moeda_cotacao;
            double valor;

            Console.WriteLine("Adicionar par de moedas:");
            Console.WriteLine("Digite o codigo da moeda base: ");
            codigo_moeda_base = Console.ReadLine();
            moeda_base = moedas.SingleOrDefault(r => r.Codigo == codigo_moeda_base);
            if (moeda_base == null)
            {
                Console.WriteLine("Moeda com esse codigo nao foi encontrada");
                return;
            }

            Console.WriteLine("Digite o codigo da moeda de cotacao: ");
            codigo_moeda_cotacao = Console.ReadLine();
            moeda_cotacao = moedas.SingleOrDefault(r => r.Codigo == codigo_moeda_cotacao);
            if (moeda_cotacao == null)
            {
                Console.WriteLine("Moeda com esse codigo nao foi encontrada");
                return;
            }

            Console.WriteLine("Digite o valor da cotacao: ");
            valor = Double.Parse(Console.ReadLine());

            ParMoeda novo_par_moeda = new ParMoeda(moeda_base, moeda_cotacao, valor);
            parMoedas.Add(novo_par_moeda);
        }

        public static void RemoverParMoeda()
        {
            String codigo_moeda_base;
            String codigo_moeda_cotacao;
            Moeda moeda_base;
            Moeda moeda_cotacao;

            Console.WriteLine("Remover par de moedas:");
            Console.WriteLine("Digite o codigo da moeda base: ");
            codigo_moeda_base = Console.ReadLine();
            moeda_base = moedas.SingleOrDefault(r => r.Codigo == codigo_moeda_base);
            if (moeda_base == null)
            {
                Console.WriteLine("Moeda com esse codigo nao foi encontrada");
                return;
            }

            Console.WriteLine("Digite o codigo da moeda de cotacao: ");
            codigo_moeda_cotacao = Console.ReadLine();
            moeda_cotacao = moedas.SingleOrDefault(r => r.Codigo == codigo_moeda_cotacao);
            if (moeda_cotacao == null)
            {
                Console.WriteLine("Moeda com esse codigo nao foi encontrada");
                return;
            }

            ParMoeda par_moeda_a_ser_removido = parMoedas.SingleOrDefault(r => r.moedaBase == moeda_base && r.moedaCotacao == moeda_cotacao);
            if (par_moeda_a_ser_removido != null)
            {
                String selecao;
                Console.WriteLine("Remover essa moeda? (s/n)");
                par_moeda_a_ser_removido.Imprime();
                selecao = Console.ReadLine();
                if (selecao == "s")
                {
                    parMoedas.Remove(par_moeda_a_ser_removido);
                }
            }
        }
    }
}
