using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    internal class Transação
    {
        public Transação() { }
        public Transação(double valor, bool crédito)
        {
            Valor = valor;
            Crédito = crédito;
        }
        public double Valor { get; set; }
        public bool Crédito { get; set; }
    }
}
