using System;

namespace ControleFinanceiroPessoal
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario usuario = new Usuario("John Doe", "john.doe@example.com", "senha123");
            usuario.AdicionarReceita(1000, DateTime.Now, "Salário");
            usuario.AdicionarReceita(500, DateTime.Now, "Vendas");
            usuario.AdicionarDespesa(200, DateTime.Now, "Alimentação");
            usuario.AdicionarDespesa(50, DateTime.Now, "Transporte");
            usuario.AdicionarCartaoCredito(2000, DateTime.Now.AddDays(30));
            usuario.AdicionarInvestimento("Ações", 1000, DateTime.Now, 5);
            usuario.AdicionarDespesaOrcamento(300, DateTime.Now, "Lazer");
            usuario.GerarRelatorios();
        }
    }
}
