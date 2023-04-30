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
        //aplicacao.clientes.Add(new Cliente(0, "Bob", "bob@gmail.com", "123456789123", "123"));
        //aplicacao.corretoras[0].InsereCarteira(new Carteira("dhsjakhjdksahjd", aplicacao.clientes[0]));

        Corretora corretora;

        aplicacao.ImprimeCorretoras();
        corretora = aplicacao.EncontrarCorretora();

        if (corretora != null)
        {
            corretora.Imprime();
        }
    }
}