using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public static void AdicionarMoeda()
        {
            Moeda nova_moeda;
            String codigo, nome;

            do
            {
                Console.Clear();
                Console.WriteLine("Inserir moeda ");
                Console.WriteLine("Digite o codigo da moeda: ");

                codigo = Console.ReadLine();
            } while (codigo == "");

            if (moedas.Find(r => r.Codigo == codigo) != null)
            {
                Console.Clear();
                Console.WriteLine("Codigo jah existe");
                Console.WriteLine("Aperte qualquer botao para continuar...");
                Console.ReadKey();
                return;
            }

            do
            {
                Console.WriteLine("Digite o nome da moeda: ");
                nome = Console.ReadLine();
            } while (nome == "");
            
            nova_moeda = AdicionarMoeda(codigo, nome);
            Console.Clear();
            Console.WriteLine("Moeda adicionada: ");
            nova_moeda.Imprime();
            Console.WriteLine("Aperte qualquer botao para continuar...");
            Console.ReadKey();
        }

        public static void AdicionarMoeda(Moeda nova_moeda)
        {
            moedas.Add(nova_moeda);
        }

        public static Moeda AdicionarMoeda(string codigo, string nome)
        {
            Moeda nova_moeda = new Moeda(codigo, nome);
            moedas.Add(nova_moeda);
            return nova_moeda;
        }

        public static void RemoverMoeda(Moeda moeda)
        {
            Moeda moeda_a_ser_removida = moedas.Find(r => r == moeda);
            if (moeda_a_ser_removida != null)
            {
                moedas.Remove(moeda_a_ser_removida);
            }
        }

        public static Moeda? EncontrarMoeda()
        {
            Moeda? moeda;
            String codigo;

            Console.WriteLine("Inserir codigo da moeda: ");
            codigo = Console.ReadLine();

            moeda = EncontrarMoeda(codigo);

            if (moeda == null)
            {
                Console.Clear();
                Console.WriteLine("Moeda nao existe");
                Console.WriteLine("Aperte qualquer botao para continuar...");
                Console.ReadKey();
                return null;
            }

            return moeda;
        }

        public static Moeda? EncontrarMoeda(String codigo)
        {
            Moeda? moeda;
            moeda = moedas.Find(r => r.Codigo == codigo);
            return moeda;
        }

        public static void ImprimeMoedas()
        {
            Console.WriteLine("Moedas");

            if (moedas.Count() < 1)
            {
                Console.WriteLine("Nenhuma moeda encontrada");
            }
            else
            {
                foreach (Moeda moeda in moedas)
                {
                    moeda.Imprime();
                }
            }
            
            Console.WriteLine("Aperte qualquer botao para continuar...");
            Console.ReadKey();
        }

        public static void AdicionarParMoeda()
        {
            ParMoeda novo_par_moeda;
            Moeda moeda_base, moeda_cotacao;
            double valor;

            Console.Clear();
            Console.WriteLine("Inserir par de moedas");

            moeda_base = EncontrarMoeda();

            if (moeda_base == null)
            {
                return;
            }

            moeda_cotacao = EncontrarMoeda();

            if (moeda_cotacao == null)
            {
                return;
            }

            if (moeda_cotacao == moeda_base)
            {
                Console.Clear();
                Console.WriteLine("Moeda eh igual a moeda base");
                Console.WriteLine("Aperte qualquer botao para continuar...");
                Console.ReadKey();
                return;
            }

            do
            {
                Console.WriteLine("Digite o valor (nao pode ser negativo): ");
                valor = Double.Parse(Console.ReadLine());
            } while (valor < 0);

            novo_par_moeda = AdicionarParMoeda(moeda_base, moeda_cotacao, valor);

            Console.Clear();
            Console.WriteLine("Par inserido: ");
            novo_par_moeda.Imprime();
            Console.WriteLine("Aperte qualquer botao para continuar...");
            Console.ReadKey();
        }

        public static void AdicionarParMoeda(ParMoeda novo_par_moeda)
        {
            parMoedas.Add(novo_par_moeda);
        }

        public static ParMoeda AdicionarParMoeda(Moeda moeda_base, Moeda moeda_cotacao, double valor)
        {
            ParMoeda novo_par_moeda = new ParMoeda(moeda_base, moeda_cotacao, valor);
            parMoedas.Add(novo_par_moeda);
            return novo_par_moeda;
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

            if (parMoedas.Count() < 1)
            {
                Console.WriteLine("Nenhum par encontrado");
            }
            else
            {
                foreach (ParMoeda parMoeda in parMoedas)
                {
                    parMoeda.Imprime();
                }
            }

            Console.WriteLine("Aperte qualquer botao para continuar...");
            Console.ReadKey();
        }

        public static ParMoeda? EncontrarParMoeda()
        {
            ParMoeda? par_moeda;
            Moeda moeda_base, moeda_cotacao;

            Console.WriteLine("Encontrar moeda base");
            moeda_base = EncontrarMoeda();

            if (moeda_base == null)
            {
                return null;
            }

            Console.WriteLine("Encontrar moeda de cotacao");
            moeda_cotacao = EncontrarMoeda();

            if (moeda_cotacao == null)
            {
                return null;
            }

            par_moeda = EncontrarParMoeda(moeda_base, moeda_cotacao);

            if (par_moeda == null)
            {
                Console.Clear();
                Console.WriteLine("Par moeda nao existe");
                Console.WriteLine("Aperte qualquer botao para continuar...");
                Console.ReadKey();
            }

            return par_moeda;
        }

        public static ParMoeda? EncontrarParMoeda(Moeda moeda_base, Moeda moeda_cotacao)
        {
            ParMoeda? par_moeda;
            par_moeda = parMoedas.Find(r => r.moedaBase == moeda_base && r.moedaCotacao == moeda_cotacao);
            return par_moeda;
        }

        public Corretora AdicionarCorretora(String nome)
        {
            Corretora nova_corretora = new Corretora(novo_codigo_corretora, nome);
            corretoras.Add(nova_corretora);
            novo_codigo_corretora++;
            return nova_corretora;
        }

        public void CadastrarCorretora()
        {
            String nome = "";

            do
            {
                Console.Clear();
                Console.WriteLine("Cadastrar corretora");
                Console.WriteLine("Digite o nome da corretora:");
                nome = Console.ReadLine();
                AdicionarCorretora(nome);
            } while (nome == "");
        }
        
        public void ImprimeCorretoras()
        {
            Console.WriteLine("Corretoras");

            if (corretoras.Count() < 1)
            {
                Console.WriteLine("Nenhuma corretora encontrada");
            }
            else
            {
                foreach (Corretora corretora in corretoras)
                {
                    corretora.Imprime();
                }
            }

            Console.WriteLine("Aperte qualquer botao para continuar...");
            Console.ReadKey();
        }

        public Corretora? EncontrarCorretora()
        {
            Corretora? corretora;
            ConsoleKeyInfo sel_modo;

            Console.Clear();
            Console.WriteLine("Encontrar corretora");
            Console.WriteLine("Encontrar corretora pelo codigo (d) ou nome (n)?");
            sel_modo = Console.ReadKey();

            Console.Clear();
            if (sel_modo.Key == ConsoleKey.D)
            {
                int codigo;

                do
                {
                    Console.WriteLine("Encontrar corretora");
                    Console.WriteLine("Digite o codigo:");
                    codigo = int.Parse(Console.ReadLine());
                    Console.Clear();
                } while (codigo <= 0 || codigo > corretoras.Count());
                
                corretora = EncontrarCorretora(codigo);
            }
            else if (sel_modo.Key == ConsoleKey.N)
            {
                String nome;
                Console.WriteLine("Encontrar corretora");
                Console.WriteLine("Digite o nome: ");
                nome = Console.ReadLine();
                corretora = EncontrarCorretora(nome);
            }
            else
            {
                Console.WriteLine("Opcao invalida");
                return null;
            }

            if(corretora == null)
            {
                Console.WriteLine("Corretora nao encontrada");
            }

            return corretora;
        }

        public Corretora? EncontrarCorretora(int codigo)
        {
            Corretora? corretora;
            corretora = corretoras.Find(r => r.codigo == codigo);
            return corretora;
        }

        public Corretora? EncontrarCorretora(String nome)
        {
            Corretora? corretora = null;
            List<Corretora> corretoras_encontradas = new List<Corretora>();
            corretoras_encontradas = corretoras.FindAll(r => r.nome == nome);

            if (corretoras_encontradas.Count() == 1)
            {
                corretora = corretoras_encontradas.ElementAt(0);
            }
            else if (corretoras_encontradas.Count() > 1)
            {
                int sel_corr = 1;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Corretoras encontradas");
                    foreach (Corretora corretora_encontrada in corretoras_encontradas)
                    {
                        corretora_encontrada.Imprime();
                    }
                    Console.WriteLine("Escolha a corretora (1a, 2a, ..., na): ");
                    sel_corr = int.Parse(Console.ReadLine());
                } while (sel_corr <= 0 || sel_corr > corretoras_encontradas.Count());
                
                corretora = corretoras_encontradas.ElementAt(sel_corr - 1);
            }

            return corretora;
        }

        public Cliente AdicionarCliente(String nome, String email, String celular, String passhash)
        {
            Cliente novo_cliente = new Cliente(novo_codigo_cliente, nome, email, celular, passhash);
            novo_codigo_cliente++;
            clientes.Add(novo_cliente);
            return novo_cliente;
        }

        public void CadastrarCliente()
        {
            String nome, email, celular, senha, passhash;
            Cliente novo_cliente;

            Console.WriteLine("Cadastrar cliente");
            Console.WriteLine("Digite o nome do cliente:");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o email do cliente:");
            email = Console.ReadLine();
            Console.WriteLine("Digite o celular do cliente:");
            celular = Console.ReadLine();
            Console.WriteLine("Digite a senha do cliente:");
            senha = Console.ReadLine();

            passhash = "batata" + senha;

            novo_cliente = AdicionarCliente(nome, email, celular, passhash);

            CadastrarCarteira(novo_cliente);
        }

        public void ImprimeClientes()
        {
            Console.WriteLine("Clientes");
            if (clientes.Count() < 1)
            {
                Console.WriteLine("Nenhum cliente encontrado");
            }
            else
            {
                foreach (Cliente cliente in clientes)
                {
                    cliente.Imprime();
                }
            }
        }

        public Cliente EncontrarCliente(int codigo)
        {
            Cliente? cliente;
            cliente = clientes.Find(r => r.Codigo == codigo);
            return cliente;
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

            Console.Clear();
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
                Console.WriteLine("Aperte qualquer botao para continuar");
                Console.ReadKey();
                return;
            }

            MenuCliente();
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
                Console.WriteLine("Aperte qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Selecionar carteira");

            ConsoleKeyInfo sel_corr;
            Corretora corretora;

            Console.WriteLine("Selecionar corretora");
            Console.WriteLine("Selecionar a corretora por codigo (d) ou nome (n)?");
            sel_corr = Console.ReadKey();

            Console.Clear();

            if (sel_corr.Key == ConsoleKey.D)
            {
                int codigo_corretora = 0;

                Console.WriteLine("Digite o codigo da corretora: ");
                codigo_corretora = int.Parse(Console.ReadLine());

                if (codigo_corretora < 0 || codigo_corretora > corretoras.Count())
                {
                    Console.Clear();
                    Console.WriteLine("Codigo invalido");
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }

                corretora = corretoras.Find(r => r.codigo == codigo_corretora);

                if (corretora == null)
                {
                    Console.Clear();
                    Console.WriteLine("Corretora nao encontrada");
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }
            }
            else if(sel_corr.Key == ConsoleKey.N)
            {
                String nome_corretora;
                List<Corretora> corretoras_encontradas = new List<Corretora>();

                Console.WriteLine("Digite o nome da corretora: ");
                nome_corretora = Console.ReadLine();

                corretoras_encontradas = corretoras.FindAll(r => r.nome == nome_corretora);

                if (corretoras_encontradas.Count() == 0)
                {
                    Console.WriteLine("Nenhuma corretora encontrada");
                    Console.WriteLine("Aperte qualquer tecla para continuar...");
                    Console.ReadKey();
                    return;
                }
                else if(corretoras_encontradas.Count() == 1)
                {
                    corretora = corretoras_encontradas.ElementAt(0);
                }
                else
                {
                    int codigo_corretora;

                    Console.WriteLine("Corretoras encontradas:");
                    foreach(Corretora corretora_encontrada in corretoras_encontradas)
                    {
                        corretora_encontrada.Imprime();
                    }

                    do
                    {
                        Console.WriteLine("Digite o codigo da corretora selecionada");
                        codigo_corretora = int.Parse(Console.ReadLine());

                        corretora = corretoras_encontradas.Find(r => r.codigo == codigo_corretora);
                    } while(corretora == null);
                }
            }
            else
            {
                Console.WriteLine("Opcao invalida");
                return;
            }

            List<Carteira> carteiras_encontradas = new List<Carteira>();
            carteiras_encontradas = corretora.carteiras.FindAll(r => r.cliente == cliente_logado);

            if (carteiras_encontradas.Count() == 0 )
            {
                Console.Clear();
                Console.WriteLine("Nenhuma carteira encontrada");
                Console.WriteLine("Aperte qualquer tecla para continuar...");
                Console.ReadKey();
            }
            else if(carteiras_encontradas.Count() == 1)
            {
                carteira_selecionada = carteiras_encontradas.ElementAt(0);
            }
            else
            {
                

                int sel_cart;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Selecionar carteira");
                    foreach (Carteira carteira in carteiras_encontradas)
                    {
                        carteira.Imprime();
                    }
                    Console.WriteLine("Escolha a carteira (1, 2, ..., n):");
                    sel_cart = int.Parse(Console.ReadLine());
                } while (sel_cart < 1 || sel_cart > carteiras_encontradas.Count());

                carteira_selecionada = carteiras_encontradas.ElementAt(sel_cart - 1);
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
            double quantidade_a_depositar = 0;

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
            double quantidade_a_sacar = 0;

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
                    MenuLogin();
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
            Console.WriteLine("Menu do admin");
            Console.WriteLine("");
            Console.WriteLine("1 - Inserir moeda");
            Console.WriteLine("2 - Remover moeda WIP");
            Console.WriteLine("3 - Imprimir moedas");
            Console.WriteLine("4 - Inserir par de moeda");
            Console.WriteLine("5 - Remover par de moeda WIP");
            Console.WriteLine("6 - Imprimir pares de moedas");
            Console.WriteLine("7 - Cadastrar corretora");
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
                    //LerMoeda();
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
                    //LerParMoeda();
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

        public void MenuLogin()
        {
            ConsoleKeyInfo sel_l;

            Console.Clear();
            Console.WriteLine("Menu do cliente");
            Console.WriteLine("");
            Console.WriteLine("1 - Fazer login");
            Console.WriteLine("2 - Cadastrar");
            Console.WriteLine("");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("");
            Console.WriteLine("Digite para escolher uma acao");

            sel_l = Console.ReadKey();

            Console.Clear();

            switch (sel_l.Key)
            {
                case ConsoleKey.D0:
                    Console.WriteLine("Saindo do menu de login...");
                    Console.WriteLine("Aperte qualquer botao para continuar...");
                    Console.ReadKey();
                    return;
                case ConsoleKey.D1:
                    LogarCliente();
                    break;
                case ConsoleKey.D2:
                    CadastrarCliente();
                    break;
                default:
                    Console.WriteLine("Acao invalida");
                    Console.WriteLine("Aperte qualquer botao para continuar...");
                    Console.ReadKey();
                    break;
            }

            MenuLogin();
        }

        public void MenuCliente()
        {
            ConsoleKeyInfo sel_c;

            while(carteira_selecionada == null) 
            { 
                SelecionarCarteira();
            }

            Console.Clear();
            Console.WriteLine("Menu do cliente");
            Console.WriteLine("");
            Console.WriteLine("1 - Imprimir carteira");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Sacar");
            Console.WriteLine("4 - Selecionar outra carteira");
            Console.WriteLine("5 - Criar outra carteira");
            Console.WriteLine("");
            Console.WriteLine("0 - Deslogar");
            Console.WriteLine("");
            Console.WriteLine("Digite para escolher uma acao");

            sel_c = Console.ReadKey();

            Console.Clear();

            switch (sel_c.Key)
            {
                case ConsoleKey.D0:
                    Deslogar();
                    carteira_selecionada = null;
                    Console.WriteLine("Saindo do menu de cliente...");
                    Console.WriteLine("Aperte qualquer botao para continuar...");
                    Console.ReadKey();
                    return;
                case ConsoleKey.D1:
                    Console.WriteLine("Carteira selecionada");
                    carteira_selecionada.Imprime();
                    Console.WriteLine("Aperte qualquer botao para continuar...");
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    LerEDepositar();
                    break;
                case ConsoleKey.D3:
                    LerESacar();
                    break;
                case ConsoleKey.D4:
                    SelecionarCarteira();
                    break;
                case ConsoleKey.D5:
                    CadastrarCarteira();
                    break;
                default:
                    Console.WriteLine("Acao invalida");
                    Console.WriteLine("Aperte qualquer botao para continuar...");
                    Console.ReadKey();
                    break;
            }

            MenuCliente();
        }
    }
}
