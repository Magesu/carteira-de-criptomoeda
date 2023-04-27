using Carteira_de_criptomoeda;
using System.Net.Security;

internal class Program
{
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

        AplicacaoCriptomoedas aplicacao = new AplicacaoCriptomoedas();

        aplicacao.CadastrarCorretora();
        aplicacao.CadastrarCliente();

        aplicacao.ImprimeCorretoras();
        aplicacao.ImprimeClientes();

        aplicacao.LogarCliente();
        aplicacao.cliente_logado.Imprime();
    }
}