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
        public contaCorrente(int numero, double saldo, bool especial, double limite, List<Transação> movimentações, Cliente cliente)
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
        public List<Transação> Movimentações { get; set; }
        public Cliente Cliente { get; set; }
        public void Saque(double valor)
        {
            if (valor > Saldo)
            {
                return;
            }
            if (valor <= Limite + Saldo)
            {
                Saldo -= valor;
                Movimentações.Add(new Transação(valor, false));
            }
        }
        public void Deposito(double valor)
        {
            Saldo += valor;
            Movimentações.Add(new Transação(valor, true));
        }
        public void Transferencia(double valor, contaCorrente conta)
        {
            if (valor > Saldo)
            {
                return;
            }
            if (valor <= Limite + Saldo)
            {
                Saldo -= valor;
                conta.Saldo += valor;
                Movimentações.Add(new Transação(valor, false));
                conta.Movimentações.Add(new Transação(valor, true));
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
