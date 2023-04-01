using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carteira_de_criptomoeda
{
    internal class Cliente
    {
        public int Codigo { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Celular { get; set; }
        public String PassHash { get; set; }

        public Cliente() { }

        public Cliente(int codigo, String nome, String email, String celular, String passHash)
        {
            Codigo = codigo;
            Nome = nome;
            Email = email;
            Celular = celular;
            PassHash = passHash;
        }

        public void Imprime()
        {
            Console.WriteLine("[Codigo: {0} Nome: {1} Email: {2} Celular: {3} PassHash: {4}]", Codigo, Nome, Email, Celular, PassHash);
        }
    }
}
