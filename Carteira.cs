using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carteira_de_criptomoeda
{
    internal class Carteira
    {
        public String endereco { get; set; }
        public Cliente cliente { get; set; }
        public List<ItemCarteira> itensCarteira; // WIP

        public Carteira()
        {
            this.itensCarteira = new List<ItemCarteira>();
        }

        public Carteira(String endereco, Cliente cliente, List<ItemCarteira> itensCarteira)
        {
            this.endereco = endereco;
            this.cliente = cliente;
            this.itensCarteira = new List<ItemCarteira>();
        }

        public void AdicionarItemCarteira(ItemCarteira novo_item_carteira)
        {
            itensCarteira.Add(novo_item_carteira);
        }

        public void InsereItemCarteira(Moeda moeda, double quant) //WIP
        {

        }

        public void Imprime() // WIP
        {
            Console.WriteLine("[endereco: {0}, cliente: {1}");

        }

        public void Deposita(Moeda moeda, double quant) // WIP
        {

        }

        public void Saca(Moeda moeda, double quant) // WIP
        {

        }
    }
}
