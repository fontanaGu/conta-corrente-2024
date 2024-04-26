namespace ContaCorrente.ConsoleApp.pastaCliente;

public class Cliente
{
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