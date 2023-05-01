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
            Console.Write("Codigo: {0}\tNome: {1}\tEmail: {2}\t Celular: {3}", Codigo, Nome, Email, Celular);
        }
    }
}