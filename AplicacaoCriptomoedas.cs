using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carteira_de_criptomoeda
{
    internal class AplicacaoCriptomoedas
    {
        public static List<Moeda> moedas = new List<Moeda>();
        public static List<ParMoeda> parMoedas = new List<ParMoeda>();
        public List<Corretora> corretoras;
        public List<Cliente> clientes;
        public int novo_codigo_corretora { get; private set; }
        public int novo_codigo_cliente { get; private set; }

        public AplicacaoCriptomoedas()
        {
            this.corretoras = new List<Corretora>();
            this.clientes = new List<Cliente>();
            this.novo_codigo_cliente = 1;
            this.novo_codigo_corretora = 1;
        }

        public static void AdicionarMoeda(string codigo, string nome)
        {
            Moeda nova_moeda = new Moeda(codigo, nome);
            moedas.Add(nova_moeda);
        }

        public static void RemoverMoeda(Moeda moeda)
        {
            Moeda moeda_a_ser_removida = moedas.Find(r => r == moeda);
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
            ParMoeda par_moeda_a_ser_removido = parMoedas.Find(r => r.moedaBase == moeda_base && r.moedaCotacao == moeda_cotacao);
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

        public static void LerMoeda()
        {
            String codigo, nome;
            Console.WriteLine("Inserir moeda ");

            do
            {
                Console.WriteLine("Digite o codigo da moeda: ");
                codigo = Console.ReadLine();
                if (moedas.Find(r => r.Codigo == codigo) != null)
                {
                    Console.WriteLine("Codigo jah existe");
                }
            } while (moedas.Find(r => r.Codigo == codigo) != null);

            Console.WriteLine("Digite o nome da moeda: ");
            nome = Console.ReadLine();
            AdicionarMoeda(codigo, nome);
        }

        public static void LerParMoeda()
        {
            Moeda moeda_base, moeda_cotacao;
            double valor;

            Console.WriteLine("Inserir par de moedas");

            do
            {
                String codigo;
                Console.WriteLine("Inserir codigo da moeda base: ");
                codigo = Console.ReadLine();
                moeda_base = moedas.Find(r => r.Codigo == codigo);
                if (moeda_base == null)
                {
                    Console.WriteLine("Moeda nao existe");
                }
            } while (moeda_base == null);

            do
            {
                String codigo;
                Console.WriteLine("Digite o codigo da moeda de cotacao: ");
                codigo = Console.ReadLine();
                moeda_cotacao = moedas.Find(r => r.Codigo == codigo);
                if (moeda_cotacao == null)
                {
                    Console.WriteLine("Moeda nao existe");
                }
            } while (moeda_cotacao == null);

            Console.WriteLine("Digite o valor: ");
            valor = Double.Parse(Console.ReadLine());

            AdicionarParMoeda(moeda_base, moeda_cotacao, valor);
        }

        public void ImprimeCorretoras()
        {
            foreach(Corretora corretora in corretoras)
            {
                corretora.Imprime();
            }
        }

        public void CadastrarCorretora()
        {
            String nome;

            Console.WriteLine("Cadastrar corretora");
            Console.WriteLine("Digite o nome da corretora:");
            nome = Console.ReadLine();

            corretoras.Add(new Corretora(novo_codigo_corretora,nome));
            novo_codigo_corretora++;
        }
        
        public void ImprimeClientes()
        {
            foreach (Cliente cliente in clientes)
            {
                cliente.Imprime();
            }
        }

        public void CadastrarCliente()
        {
            String nome, email, celular, passhash;

            Console.WriteLine("Cadastrar cliente");
            Console.WriteLine("Digite o nome do cliente:");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o email do cliente:");
            email = Console.ReadLine();
            Console.WriteLine("Digite o celular do cliente:");
            celular = Console.ReadLine();
            Console.WriteLine("Digite a senha do cliente:");
            passhash = Console.ReadLine();

            clientes.Add(new Cliente(novo_codigo_cliente, nome, email, celular, passhash));
            novo_codigo_cliente++;
        }
    }
}
