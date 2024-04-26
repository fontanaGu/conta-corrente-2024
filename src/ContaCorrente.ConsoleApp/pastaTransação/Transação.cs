namespace ContaCorrente.ConsoleApp.pastaTransação;

public class Transação
{
    public Transação(double valor, string tipo)
    {
        Valor = valor;
        Tipo = tipo;
    }

    public double Valor { get; set; }
    public string Tipo { get; set; }
}