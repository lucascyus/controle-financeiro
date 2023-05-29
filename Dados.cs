using System;
using System.Collections.Generic;
using System.IO;

namespace ControleFinanceiroPessoal
{
    public interface ITransacao
    {
        decimal Valor { get; set; }
        DateTime Data { get; set; }
        string Categoria { get; set; }
    }
    public class ControleFinanceiro
    {
        private List<Usuario> Usuarios { get; set; }

        public ControleFinanceiro()
        {
            Usuarios = new List<Usuario>();
        }
        public void AdicionarUsuario(string nome, string email, string senha)
        {
            Usuarios.Add(new Usuario(nome, email, senha));
        }
    }
    public class Usuario
    {
        private List<Receita> Receitas { get; set; }
        private List<Despesa> Despesas { get; set; }
        private List<CartaoCredito> CartoesCredito { get; set; }
        private List<Investimento> Investimentos { get; set; }
        private List<Despesa> Orcamento { get; set; }

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Receitas = new List<Receita>();
            Despesas = new List<Despesa>();
            CartoesCredito = new List<CartaoCredito>();
            Investimentos = new List<Investimento>();
            Orcamento = new List<Despesa>();
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public void AdicionarReceita(decimal valor, DateTime data, string categoria)
        {
            Receitas.Add(new Receita(valor, data, categoria));
        }
        public void AdicionarDespesa(decimal valor, DateTime data, string categoria)
        {
            Despesas.Add(new Despesa(valor, data, categoria));
        }
        public void AdicionarCartaoCredito(decimal limiteCredito, DateTime dataVencimentoFatura)
        {
            CartoesCredito.Add(new CartaoCredito(limiteCredito, dataVencimentoFatura));
        }
        public void AdicionarInvestimento(string tipo, decimal valorInvestido, DateTime data, decimal retornoEsperado)
        {
            Investimentos.Add(new Investimento(tipo, valorInvestido, data, retornoEsperado));
        }
        public void AdicionarDespesaOrcamento(decimal valor, DateTime data, string categoria)
        {
            Orcamento.Add(new Despesa(valor, data, categoria));
        }
        public void GerarRelatorios()
        {
            Console.WriteLine("Relatórios Financeiros");
            Console.WriteLine("-----------------------");
            Console.WriteLine();

            Console.WriteLine("Receitas:");
            foreach (var receita in Receitas)
            {
                Console.WriteLine($"Valor: {receita.Valor}, Data: {receita.Data}, Categoria: {receita.Categoria}");
            }
            Console.WriteLine();

            Console.WriteLine("Despesas:");
            foreach (var despesa in Despesas)
            {
                Console.WriteLine($"Valor: {despesa.Valor}, Data: {despesa.Data}, Categoria: {despesa.Categoria}");
            }
            Console.WriteLine();

            Console.WriteLine("Cartões de Crédito:");
            foreach (var cartao in CartoesCredito)
            {
                Console.WriteLine($"Limite de Crédito: {cartao.LimiteCredito}, Saldo Atual: {cartao.SaldoAtual}, Despesas: {cartao.Despesas}, Valor da Fatura Atual: {cartao.ValorFaturaAtual}, Data de Vencimento da Fatura: {cartao.DataVencimentoFatura}");
            }
            Console.WriteLine();

            Console.WriteLine("Investimentos:");
            foreach (var investimento in Investimentos)
            {
                Console.WriteLine($"Tipo: {investimento.Tipo}, Valor Investido: {investimento.ValorInvestido}, Data: {investimento.Data}, Retorno Esperado: {investimento.RetornoEsperado}");
            }
            Console.WriteLine();

            Console.WriteLine("Orçamento:");
            foreach (var despesa in Orcamento)
            {
                Console.WriteLine($"Valor: {despesa.Valor}, Data: {despesa.Data}, Categoria: {despesa.Categoria}");
            }
            Console.WriteLine();

            Console.WriteLine("Relatórios gerados");

            
            ExportarRelatorios("relatorios.txt");
        }
        private void ExportarRelatorios(string nomeArquivo)
        {
            using (StreamWriter writer = new StreamWriter(nomeArquivo))
            {
                writer.WriteLine("Relatórios Financeiros");
                writer.WriteLine("-----------------------");
                writer.WriteLine();

                writer.WriteLine("Receitas:");
                foreach (var receita in Receitas)
                {
                    writer.WriteLine($"Valor: {receita.Valor}, Data: {receita.Data}, Categoria: {receita.Categoria}");
                }
                writer.WriteLine();

                writer.WriteLine("Despesas:");
                foreach (var despesa in Despesas)
                {
                    writer.WriteLine($"Valor: {despesa.Valor}, Data: {despesa.Data}, Categoria: {despesa.Categoria}");
                }
                writer.WriteLine();

                writer.WriteLine("Cartões de Crédito:");
                foreach (var cartao in CartoesCredito)
                {
                    writer.WriteLine($"Limite de Crédito: {cartao.LimiteCredito}, Saldo Atual: {cartao.SaldoAtual}, Despesas: {cartao.Despesas}, Valor da Fatura Atual: {cartao.ValorFaturaAtual}, Data de Vencimento da Fatura: {cartao.DataVencimentoFatura}");
                }
                writer.WriteLine();

                writer.WriteLine("Investimentos:");
                foreach (var investimento in Investimentos)
                {
                    writer.WriteLine($"Tipo: {investimento.Tipo}, Valor Investido: {investimento.ValorInvestido}, Data: {investimento.Data}, Retorno Esperado: {investimento.RetornoEsperado}");
                }
                writer.WriteLine();

                writer.WriteLine("Orçamento:");
                foreach (var despesa in Orcamento)
                {
                    writer.WriteLine($"Valor: {despesa.Valor}, Data: {despesa.Data}, Categoria: {despesa.Categoria}");
                }
                writer.WriteLine();

                writer.WriteLine("Relatórios gerados com sucesso.");
            }
        }
    }
    public class Receita : ITransacao
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Categoria { get; set; }

        public Receita(decimal valor, DateTime data, string categoria)
        {
            Valor = valor;
            Data = data;
            Categoria = categoria;
        }
    }
    public class Despesa : ITransacao
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Categoria { get; set; }

        public Despesa(decimal valor, DateTime data, string categoria)
        {
            Valor = valor;
            Data = data;
            Categoria = categoria;
        }
    }
    public class CartaoCredito
    {
        public decimal LimiteCredito { get; private set; }
        public decimal SaldoAtual { get; private set; }
        public decimal Despesas { get; private set; }
        public decimal ValorFaturaAtual { get; private set; }
        public DateTime DataVencimentoFatura { get; private set; }

        public CartaoCredito(decimal limiteCredito, DateTime dataVencimentoFatura)
        {
            LimiteCredito = limiteCredito;
            SaldoAtual = 0;
            Despesas = 0;
            ValorFaturaAtual = 0;
            DataVencimentoFatura = dataVencimentoFatura;
        }
    }
    public class Investimento
    {
        public string Tipo { get; private set; }
        public decimal ValorInvestido { get; private set; }
        public DateTime Data { get; private set; }
        public decimal RetornoEsperado { get; private set; }

        public Investimento(string tipo, decimal valorInvestido, DateTime data, decimal retornoEsperado)
        {
            Tipo = tipo;
            ValorInvestido = valorInvestido;
            Data = data;
            RetornoEsperado = retornoEsperado;
        }
    }
}