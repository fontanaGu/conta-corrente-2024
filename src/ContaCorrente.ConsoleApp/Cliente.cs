using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    internal class Cliente
    {
        public Cliente()
        { }
                public Cliente(string nome, string sobrenome, string cpf)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
        }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
    }
}
