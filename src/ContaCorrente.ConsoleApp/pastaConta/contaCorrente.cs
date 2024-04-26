using ContaCorrente.ConsoleApp.pastaCliente;
using ContaCorrente.ConsoleApp.pastaTransação;

namespace ContaCorrente.ConsoleApp.pastaConta
{
    public class ContaCorrente
    {
        public Transação[] Historico;
        public decimal Limite { get; set; }
        public int Numero { get; set; }
        private int qtdMovimentacoes;
        public decimal Saldo { get; set; }

        public Cliente Titular { get; set; }

        public ContaCorrente(int numero, decimal saldo, decimal limite, Cliente titular)
        {
            Numero = numero;
            Saldo = saldo;
            Limite = limite;
            Titular = titular;

            Historico = new Transação[100];
        }

        public bool Sacar(decimal valor)
        {
            if (valor > Saldo + Limite)
                return false;

            Saldo -= valor;

            var movimentacao = new Transação((double)valor, "Saque");

            RegistrarMovimentacao(movimentacao);

            return true;
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;

            var movimentacao = new Transação((double)valor, "Depósito");

            RegistrarMovimentacao(movimentacao);
        }

        public bool Transferir(decimal valor, ContaCorrente destinatario)
        {
            var conseguiuSacar = Sacar(valor);

            if (!conseguiuSacar)
                return false;

            destinatario.Depositar(valor);

            return true;
        }

        public decimal ObterSaldo()
        {
            return Saldo;
        }

        private void RegistrarMovimentacao(Transação movimentacao)
        {
            if (qtdMovimentacoes < Historico.Length)
            {
                Historico[qtdMovimentacoes] = movimentacao;
                qtdMovimentacoes++;
            }
        }
    }
}
