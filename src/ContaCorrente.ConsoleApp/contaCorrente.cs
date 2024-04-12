using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente.ConsoleApp
{
    internal class contaCorrente
    {
        public contaCorrente() { }
        public contaCorrente(int numero, double saldo, bool especial, double limite, List<Movimentação> movimentações, Cliente cliente)
        {
            Numero = numero;
            Saldo = saldo;
            Especial = especial;
            Limite = limite;
            Movimentações = movimentações;
            Cliente = cliente;
        }
        public int Numero { get; set; }
        public double Saldo { get; set; }
        public bool Especial { get; set; }
        public double Limite { get; set; }
        public List<Movimentação> Movimentações { get; set; }
        public Cliente Cliente { get; set; }
        public void Saque(double valor)
        {
            if (valor <= Limite + Saldo)
            {
                Saldo -= valor;
                Movimentações.Add(new Movimentação(valor, false));
            }
        }
        public void Deposito(double valor)
        {
            Saldo += valor;
            Movimentações.Add(new Movimentação(valor, true));
        }
        public void Transferencia(double valor, contaCorrente conta)
        {
            if (valor <= Limite + Saldo)
            {
                Saldo -= valor;
                conta.Saldo += valor;
                Movimentações.Add(new Movimentação(valor, false));
                conta.Movimentações.Add(new Movimentação(valor, true));
            }
        }
        public void Extrato()
        {
            foreach (var movimentação in Movimentações)
            {
                Console.WriteLine(movimentação.Valor + " " + (movimentação.Crédito ? "Crédito" : "Débito"));
            }
        }
    }
}
