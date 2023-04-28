using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carteira_de_criptomoeda
{
    internal class Corretora
    {
        public int codigo { get; set; }
        public String nome { get; set; }
        public List<Carteira> carteiras;

        public Corretora()
        {
            this.carteiras = new List<Carteira>();
        }

        public Corretora(int codigo, String nome)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.carteiras = new List<Carteira>();
        }

        public void InsereCarteira(Carteira nova_carteira)
        {
            carteiras.Add(nova_carteira);
        }

        public void RemoveCarteira(String endereco)
        {
            var carteira_para_remover = carteiras.Find(r => r.endereco == endereco);
            if (carteira_para_remover != null)
            {
                carteiras.Remove(carteira_para_remover);
            }
        }

        public void ImprimeCarteiras()
        {
            foreach (Carteira carteira in carteiras)
            {
                carteira.Imprime();
            }
        }

        public void Imprime()
        {
            Console.WriteLine("Codigo: {0}", codigo);
            Console.WriteLine("Nome: {0}", nome);
            Console.WriteLine("Carteiras:");
            foreach(Carteira carteira in carteiras)
            {
                carteira.Imprime();
            }
        }

    }
}