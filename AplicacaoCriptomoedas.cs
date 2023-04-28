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
        public Cliente? cliente_logado { get; private set; }
        public Carteira? carteira_selecionada { get; private set; }

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
            Cliente novo_cliente;

            Console.WriteLine("Cadastrar cliente");
            Console.WriteLine("Digite o nome do cliente:");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o email do cliente:");
            email = Console.ReadLine();
            Console.WriteLine("Digite o celular do cliente:");
            celular = Console.ReadLine();
            Console.WriteLine("Digite a senha do cliente:");
            passhash = Console.ReadLine();

            novo_cliente = new Cliente(novo_codigo_cliente, nome, email, celular, passhash);
            novo_codigo_cliente++;

            clientes.Add(novo_cliente);

            CadastrarCarteira(novo_cliente);
        }

        public void CadastrarCarteira()
        {
            if(cliente_logado != null)
            {
                CadastrarCarteira(cliente_logado);
            }
        }

        public void CadastrarCarteira(Cliente cliente)
        {
            String endereco;
            Carteira carteira;
            int codigo_corretora;
            Corretora corretora_escolhida;

            Console.WriteLine("Cadastrar carteira");

            Console.WriteLine("Digite o codigo da corretora: ");
            codigo_corretora = int.Parse(Console.ReadLine());

            corretora_escolhida = corretoras.Find(r => r.codigo == codigo_corretora);
            Console.WriteLine("Digite o endereco da carteira: ");
            endereco = Console.ReadLine();

            carteira = new Carteira(endereco, cliente);
            corretora_escolhida.InsereCarteira(carteira);
        }

        public void LogarCliente()
        {
            String email, password;

            Console.WriteLine("Digite o email do cliente: ");
            email = Console.ReadLine();
            Console.WriteLine("Digite a senha do cliente: ");
            password = Console.ReadLine();

            cliente_logado = clientes.Find(r => r.Email == email && r.PassHash == password);

            if( cliente_logado == null )
            {
                Console.WriteLine("Cliente nao existe");
            }
        }

        public void Deslogar()
        {
            cliente_logado = null;

            Console.WriteLine("Cliente deslogado");
        }
        
        public void SelecionarCarteira()
        {
            if(cliente_logado != null)
            {
                int codigo_corretora;
                Corretora corretora;
                List<Carteira> carteiras_encontradas = new List<Carteira>();

                Console.WriteLine("Digite o codigo da corretora: ");
                codigo_corretora = int.Parse(Console.ReadLine());

                corretora = corretoras.Find(r => r.codigo == codigo_corretora);

                if (corretora != null)
                {
                    carteiras_encontradas = corretora.carteiras.FindAll(r => r.cliente == cliente_logado);

                    if(carteiras_encontradas.Count() == 0 )
                    {
                        Console.WriteLine("Nenhuma carteira encontrada");
                    }
                    else if(carteiras_encontradas.Count() == 1)
                    {
                        carteira_selecionada = carteiras_encontradas[0];
                    }
                    else
                    {
                        foreach(Carteira carteira in carteiras_encontradas)
                        {
                            carteira.Imprime();
                        }

                        int sel;

                        do
                        {
                            Console.WriteLine("Digite o index da carteira escolhida:");
                            sel = int.Parse(Console.ReadLine());
                        } while (sel < 0 && sel >= carteiras_encontradas.Count());

                        carteira_selecionada = carteiras_encontradas[sel];
                    }
                }
                else
                {
                    Console.WriteLine("Corretora nao encontrada");
                }
            }
        }

        public void LerEDepositar()
        {
            String moeda_codigo;
            Moeda moeda_a_depositar;
            double quantidade_a_depositar;

            Console.WriteLine("Digite o codigo da moeda: ");
            moeda_codigo = Console.ReadLine();
            moeda_a_depositar = moedas.Find(r => r.Codigo == moeda_codigo);
            Console.WriteLine("Digite a quantidade a ser depositada: ");
            quantidade_a_depositar = double.Parse(Console.ReadLine());

            carteira_selecionada.Depositar(moeda_a_depositar, quantidade_a_depositar);
        }
        
        public void LerESacar()
        {
            String moeda_codigo;
            Moeda moeda_a_sacar;
            double quantidade_a_sacar;

            Console.WriteLine("Digite o codigo da moeda: ");
            moeda_codigo = Console.ReadLine();
            moeda_a_sacar = moedas.Find(r => r.Codigo == moeda_codigo);
            Console.WriteLine("Digite a quantidade a ser sacada: ");
            quantidade_a_sacar = double.Parse(Console.ReadLine());

            carteira_selecionada.Sacar(moeda_a_sacar, quantidade_a_sacar);
        }
    }
}
