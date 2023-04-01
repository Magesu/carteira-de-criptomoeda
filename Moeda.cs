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
        public List<Carteira> carteiras; // WIP

        public Corretora() 
        {
            this.carteiras = new List<Carteira>();
        }

        public Corretora(int codigo, String nome, List<Carteira> carteiras)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.carteiras = new List<Carteira>();
        }

        public void InsereCarteira(Carteira nova_carteira)
        {
            carteiras.Add(nova_carteira);
        }

        public void ImprimeCarteiras()
        {
            foreach(Carteira carteira in carteiras)
            {
                carteira.Imprime();
            }
        }

        public void Imprime() // WIP
        {
            Console.WriteLine("[Codigo: {0}, Nome: {1}");
        }

    }
}
