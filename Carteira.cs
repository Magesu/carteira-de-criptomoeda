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
        public List<ItemCarteira> itensCarteira;

        public Carteira()
        {
            this.itensCarteira = new List<ItemCarteira>();
        }

        public Carteira(String endereco, Cliente cliente)
        {
            this.endereco = endereco;
            this.cliente = cliente;
            this.itensCarteira = new List<ItemCarteira>();
        }

        public void InsereItemCarteira(Moeda moeda, double quant)
        {
            ItemCarteira novo_item_carteira = new ItemCarteira(moeda, quant);
            itensCarteira.Add(novo_item_carteira);
        }

        public void RemoveItemCarteira(Moeda moeda)
        {
            var item_para_remover = itensCarteira.Find(r => r.moeda == moeda);
            if (item_para_remover != null)
            {
                itensCarteira.Remove(item_para_remover);
            }
        }

        public void Imprime()
        {
            Console.WriteLine("Endereco: {0}\tNum. de itens na carteira: {1}", endereco, itensCarteira.Count());
            Console.Write("Cliente: ");
            cliente.Imprime();
            Console.WriteLine();
        }

        public void ImprimeItensCarteira()
        {
            Console.WriteLine("Itens da carteira:");
            foreach (ItemCarteira item in itensCarteira)
            {
                item.Imprime();
                Console.WriteLine();
            }
        }

        public void Depositar(Moeda moeda, double quant)
        {
            ItemCarteira item_carteira = itensCarteira.Find(r => r.moeda == moeda);

            if(item_carteira != null)
            {
                item_carteira.quantidade += quant;
            }
            else
            {
                InsereItemCarteira(moeda, quant);
            }
        }

        public void Sacar(Moeda moeda, double quant)
        {
            ItemCarteira item_carteira = itensCarteira.Find(r => r.moeda == moeda);

            if(item_carteira == null)
            {
                Console.WriteLine("Item nao existe");
                return;
            }

            if(quant > item_carteira.quantidade)
            {
                Console.WriteLine("Erro: quantidade insuficiente de moedas");
                return;
            }

            item_carteira.quantidade -= quant;
        }
    }
}