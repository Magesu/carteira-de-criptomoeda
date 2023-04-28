using System;
using System.Collections.Generic;
using System.Data;
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

        public static void AdicionarMoeda(Moeda nova_moeda)
        {
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
            Console.WriteLine("Moedas");

            foreach (Moeda moeda in moedas)
            {
                moeda.Imprime();
            }

            Console.WriteLine("Aperte qualquer botao para continuar...");
            Console.ReadKey();
        }

        public static void AdicionarParMoeda(Moeda moeda_base, Moeda moeda_cotacao, double valor)
        {
            ParMoeda novo_par_moeda = new ParMoeda(moeda_base, moeda_cotacao, valor);
            parMoedas.Add(novo_par_moeda);
        }

        public static void AdicionarParMoeda(ParMoeda novo_par_moeda)
        {
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

        public static void RemoverParMoeda(ParMoeda par_moeda)
        {
            ParMoeda par_moeda_a_ser_removido = parMoedas.Find(r => r == par_moeda);
            if (par_moeda_a_ser_removido != null)
            {
                parMoedas.Remove(par_moeda_a_ser_removido);
            }
        }

        public static void ImprimeParMoedas()
        {
            Console.WriteLine("Pares de moedas");

            foreach (ParMoeda parMoeda in parMoedas)
            {
                parMoeda.Imprime();
            }

            Console.WriteLine("Aperte qualquer botao para continuar...");
            Console.ReadKey();
        }

        public static void LerMoeda()
        {
            Moeda nova_moeda;
            String codigo, nome;

            Console.Clear();
            Console.WriteLine("Inserir moeda ");
            Console.WriteLine("Digite o codigo da moeda: ");

            codigo = Console.ReadLine();

            if (moedas.Find(r => r.Codigo == codigo) != null)
            {
                Console.Clear();
                Console.WriteLine("Codigo jah existe");
                Console.WriteLine("Aperte qualquer botao para continuar...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Digite o nome da moeda: ");
                nome = Console.ReadLine();
                nova_moeda = new Moeda(codigo, nome);
                AdicionarMoeda(nova_moeda);
                Console.Clear();
                Console.WriteLine("Moeda adicionada: ");
                nova_moeda.Imprime();
                Console.WriteLine("Aperte qualquer botao para continuar...");
                Console.ReadKey();
            }
        }

        public static void LerParMoeda()
        {
            ParMoeda novo_par_moeda;
            Moeda moeda_base, moeda_cotacao;
            double valor;

            Console.Clear();
            Console.WriteLine("Inserir par de moedas");

            String codigo_moeda_base;
            Console.WriteLine("Inserir codigo da moeda base: ");
            codigo_moeda_base = Console.ReadLine();
            moeda_base = moedas.Find(r => r.Codigo == codigo_moeda_base);

            if (moeda_base == null)
            {
                Console.Clear();
                Console.WriteLine("Moeda nao existe");
                Console.WriteLine("Aperte qualquer botao para continuar...");
                Console.ReadKey();
                return;
            }

            
            String codigo_moeda_cotacao;
            Console.WriteLine("Digite o codigo da moeda de cotacao: ");
            codigo_moeda_cotacao = Console.ReadLine();
            moeda_cotacao = moedas.Find(r => r.Codigo == codigo_moeda_cotacao);

            if (moeda_cotacao == null)
            {
                Console.Clear();
                Console.WriteLine("Moeda nao existe");
                Console.WriteLine("Aperte qualquer botao para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Digite o valor: ");
            valor = Double.Parse(Console.ReadLine());

            novo_par_moeda = new ParMoeda(moeda_base, moeda_cotacao, valor);
            AdicionarParMoeda(moeda_base, moeda_cotacao, valor);

            Console.Clear();
            Console.WriteLine("Par inserido: ");
            novo_par_moeda.Imprime();
            Console.WriteLine("Aperte qualquer botao para continuar...");
            Console.ReadKey();
        }

        public void ImprimeCorretoras()
        {
            Console.WriteLine("Corretoras");

            foreach (Corretora corretora in corretoras)
            {
                corretora.Imprime();
            }

            Console.WriteLine("Aperte qualquer botao para continuar...");
            Console.ReadKey();
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
            if (cliente_logado == null)
            {
                return;
            }

            CadastrarCarteira(cliente_logado);
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

            Console.WriteLine("Fazer login");
            Console.WriteLine("Digite o email do cliente: ");
            email = Console.ReadLine();
            Console.WriteLine("Digite a senha do cliente: ");
            password = Console.ReadLine();

            cliente_logado = clientes.Find(r => r.Email == email && r.PassHash == password);
            
            if(cliente_logado == null)
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
            if (cliente_logado == null)
            {
                Console.WriteLine("Nenhum cliente esta logado");
                return;
            }

            int codigo_corretora;
            Corretora corretora;
            List<Carteira> carteiras_encontradas = new List<Carteira>();

            Console.WriteLine("Digite o codigo da corretora: ");
            codigo_corretora = int.Parse(Console.ReadLine());

            corretora = corretoras.Find(r => r.codigo == codigo_corretora);

            if (corretora == null)
            {
                Console.WriteLine("Corretora nao encontrada");
                return;
            }

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
                foreach (Carteira carteira in carteiras_encontradas)
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

        public void LerEDepositar()
        {
            if (cliente_logado == null || carteira_selecionada == null)
            {
                Console.WriteLine("Nenhum cliente logado ou nenhuma carteira selecionada");
                return;
            }

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
            if (cliente_logado == null || carteira_selecionada == null)
            {
                Console.WriteLine("Nenhum cliente logado ou nenhuma carteira selecionada");
                return;
            }

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

        public void Menu()
        {
            ConsoleKeyInfo sel_m;

            Console.Clear();
            Console.WriteLine("Menu");
            Console.WriteLine("");
            Console.WriteLine("1 - Admin");
            Console.WriteLine("2 - Cliente");
            Console.WriteLine("");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("");
            Console.WriteLine("Digite para escolher uma acao");

            sel_m = Console.ReadKey();

            Console.Clear();

            switch (sel_m.Key)
            {
                case ConsoleKey.D0:
                    Console.WriteLine("Aplicacao terminada");
                    return;
                case ConsoleKey.D1:
                    MenuAdmin();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Menu do cliente WIP");
                    Console.WriteLine("Aperte qualquer botao para continuar...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Acao invalida");
                    Console.WriteLine("Aperte qualquer botao para continuar...");
                    Console.ReadKey();
                    break;
            }

            Menu();
        }

        public void MenuAdmin()
        {
            ConsoleKeyInfo sel_a;

            Console.Clear();
            Console.WriteLine("Menu de admin");
            Console.WriteLine("");
            Console.WriteLine("1 - Inserir moeda");
            Console.WriteLine("2 - Remover moeda WIP");
            Console.WriteLine("3 - Imprimir moedas");
            Console.WriteLine("4 - Inserir par de moeda");
            Console.WriteLine("5 - Remover par de moeda WIP");
            Console.WriteLine("6 - Imprimir pares de moedas");
            Console.WriteLine("7 - Inserir corretora");
            Console.WriteLine("8 - Remover corretora WIP");
            Console.WriteLine("9 - Imprimir corretoras");
            Console.WriteLine("");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("");
            Console.WriteLine("Digite para escolher uma acao");

            sel_a = Console.ReadKey();

            Console.Clear();

            switch (sel_a.Key)
            {
                case ConsoleKey.D0:
                    Console.WriteLine("Saindo do menu de admin");
                    Console.WriteLine("Aperte qualquer botao para continuar...");
                    Console.ReadKey();
                    return;
                case ConsoleKey.D1:
                    LerMoeda();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("WIP");
                    Console.WriteLine("Aperte qualquer botao para continuar...");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    ImprimeMoedas();
                    break;
                case ConsoleKey.D4:
                    LerParMoeda();
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine("WIP");
                    Console.WriteLine("Aperte qualquer botao para continuar...");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D6:
                    ImprimeParMoedas();
                    break;
                case ConsoleKey.D7:
                    CadastrarCorretora();
                    break;
                case ConsoleKey.D8:
                    Console.WriteLine("WIP");
                    Console.WriteLine("Aperte qualquer botao para continuar...");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D9:
                    ImprimeCorretoras();
                    break;
                default:
                    Console.WriteLine("Acao invalida");
                    Console.WriteLine("Aperte qualquer botao para continuar...");
                    Console.ReadKey();
                    break;
            }

            MenuAdmin();
        }
    }
}
