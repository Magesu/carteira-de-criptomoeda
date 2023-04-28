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
        AplicacaoCriptomoedas.AdicionarParMoeda(AplicacaoCriptomoedas.moedas[0], AplicacaoCriptomoedas.moedas[1], 4);
        AplicacaoCriptomoedas.AdicionarParMoeda(AplicacaoCriptomoedas.moedas[0], AplicacaoCriptomoedas.moedas[2], 2);

        aplicacao.corretoras.Add(new Corretora(0, "Batata"));
        aplicacao.clientes.Add(new Cliente(0, "Bob", "bob@gmail.com", "123456789123", "123"));
        aplicacao.corretoras[0].InsereCarteira(new Carteira("dhsjakhjdksahjd", aplicacao.clientes[0]));

        aplicacao.ImprimeCorretoras();
        aplicacao.ImprimeClientes();

        aplicacao.LogarCliente();
        aplicacao.CadastrarCarteira();
        aplicacao.SelecionarCarteira();
        aplicacao.carteira_selecionada.Imprime();
        aplicacao.LerEDepositar();
        aplicacao.carteira_selecionada.Imprime();
        aplicacao.LerESacar();
        aplicacao.carteira_selecionada.Imprime();
    }
}