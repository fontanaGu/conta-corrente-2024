using ContaCorrente.ConsoleApp.pastaCliente;
namespace ContaCorrente.ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var cliente1 = new Cliente("", "", "");

        var contaCorrente = new pastaConta.ContaCorrente(1, 1200, 1000, cliente1);

        //visualização de saldo
        Console.WriteLine("R$ " + contaCorrente.ObterSaldo());

        //saques
        contaCorrente.Sacar(200);

        Console.WriteLine("Após saque: R$ " + contaCorrente.ObterSaldo());

        //depósitos
        contaCorrente.Depositar(400);

        Console.WriteLine("Após depósito: R$ " + contaCorrente.ObterSaldo());

        var cliente2 = new Cliente("", "", "");

        var contaCorrente2 = new pastaConta.ContaCorrente(2, 5000, 3000, cliente2);

        #region Operações Conta 2

        Console.WriteLine("R$ " + contaCorrente2.ObterSaldo());

        // transferencia
        contaCorrente.Transferir(300, contaCorrente2);

        Console.WriteLine("Após transferência: R$ " + contaCorrente2.ObterSaldo());

        #endregion

        Console.WriteLine("\nExtrato conta 1:");

        for (var i = 0; i < contaCorrente.Historico.Length; i++)
        {
            var movimentacao = contaCorrente.Historico[i];

            if (movimentacao != null)
                Console.WriteLine(movimentacao.Tipo + " " + movimentacao.Valor);
        }

        Console.WriteLine("\nExtrato conta 2:");

        for (var i = 0; i < contaCorrente2.Historico.Length; i++)
        {
            var movimentacao = contaCorrente2.Historico[i];

            if (movimentacao != null)
                Console.WriteLine(movimentacao.Tipo + " " + movimentacao.Valor);
        }

        Console.ReadLine();
    }
}