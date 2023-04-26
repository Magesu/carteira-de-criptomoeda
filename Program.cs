using Carteira_de_criptomoeda;
using System.Net.Security;

internal class Program
{
    public static void LerMoeda()
    {
        String codigo, nome;
        Console.WriteLine("Inserir moeda: ");

        do
        {
            Console.WriteLine("Digite o codigo da moeda: ");
            codigo = Console.ReadLine();
            if (MoedaDados.moedas.Find(r => r.Codigo == codigo) != null)
            {
                Console.WriteLine("Codigo jah existe");
            }
        } while (MoedaDados.moedas.Find(r => r.Codigo == codigo) != null);

        Console.WriteLine("Digite o nome da moeda: ");
        nome = Console.ReadLine();
        MoedaDados.AdicionarMoeda(codigo, nome);
    }

    public static void LerParMoeda()
    {
        Moeda moeda_base, moeda_cotacao;
        double valor;

        do
        {
            String codigo;
            Console.WriteLine("Inserir codigo da moeda base: ");
            codigo = Console.ReadLine();
            moeda_base = MoedaDados.moedas.Find(r => r.Codigo == codigo);
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
            moeda_cotacao = MoedaDados.moedas.Find(r => r.Codigo == codigo);
            if (moeda_cotacao == null)
            {
                Console.WriteLine("Moeda nao existe");
            }
        } while (moeda_cotacao == null);

        Console.WriteLine("Digite o valor: ");
        valor = Double.Parse(Console.ReadLine());

        MoedaDados.AdicionarParMoeda(moeda_base, moeda_cotacao, valor);
    }

    private static void Main(string[] args)
    {
        Corretora corretora = new Corretora(666, "Cocorretora");
        Cliente cliente1 = new Cliente(1234, "Bob", "bobbombado@gmail.com", "554112345678", "dasn4dji3abdi2sancijs1jdia");
        Cliente cliente2 = new Cliente(4321, "Banana", "bananabacana@gmail.com", "554112345679", "bdshj3abd2jhsa4bhjdbhjsa1bjhd");
        Carteira carteira1 = new Carteira("fj1dhuis2ahfida3sufo4dhsauf", cliente1);
        Carteira carteira2 = new Carteira("fj1dhuis2ahfida3sufo4dhsauf", cliente2);
        Moeda bitcoin = new Moeda("9876", "BTC");
        Moeda ether = new Moeda("1234", "ETH");
        Moeda dolar = new Moeda("6789", "USD");
        Moeda real = new Moeda("6879", "BRL");

        LerMoeda();
        LerMoeda();
        LerMoeda();
        LerMoeda();
        LerParMoeda();

        MoedaDados.ImprimeMoedas();
        MoedaDados.ImprimeParMoedas();
    }
}