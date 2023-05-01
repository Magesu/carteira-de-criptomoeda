using Carteira_de_criptomoeda;
using System.Net.Security;

internal class Program
{
    private static void Main(string[] args)
    {
        AplicacaoCriptomoedas aplicacao = new AplicacaoCriptomoedas();

        AplicacaoCriptomoedas.AdicionarMoeda("BTC","Bitcoin");
        AplicacaoCriptomoedas.AdicionarMoeda("USD","Dolar americano");
        AplicacaoCriptomoedas.AdicionarMoeda("BRL","Real brasileiro");
        AplicacaoCriptomoedas.AdicionarMoeda("ETH","Ether");
        AplicacaoCriptomoedas.AdicionarParMoeda(AplicacaoCriptomoedas.EncontrarMoeda("BTC"), AplicacaoCriptomoedas.EncontrarMoeda("USD"), 4);
        AplicacaoCriptomoedas.AdicionarParMoeda(AplicacaoCriptomoedas.EncontrarMoeda("BTC"), AplicacaoCriptomoedas.EncontrarMoeda("BRL"), 2);

        aplicacao.AdicionarCorretora("Batata");
        aplicacao.AdicionarCorretora("Banana");
        Cliente c1;
        c1 = aplicacao.AdicionarCliente("Bob", "bob@gmail.com", "123456789123", "batata123");
        aplicacao.AdicionarCarteira(aplicacao.EncontrarCorretora(1),"hfddjshfiahsjdihijadsf",c1);

        aplicacao.Menu();
    }
}