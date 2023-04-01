using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carteira_de_criptomoeda
{
    internal class Moeda
    {
        public String Codigo { get; set; }
        public String Nome { get; set; }

        public Moeda() { }

        public Moeda(string codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        public void Imprime()
        {
            Console.WriteLine("Codigo: {0} Nome: {1} ", Codigo, Nome);
        }
    }
}
