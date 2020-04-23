using System;
using System.Collections.Generic;
using System.Text;

namespace solid
{
    public class Compra
    {
        public string Cidade { get; set; }
        public double Valor { get; set; }
    }

    public class CalculadoraDePrecos
    {
        public ITabela Tabela { get; }
        public IFrete Frete { get; }

        public CalculadoraDePrecos(ITabela tabela, IFrete frete)
        {
            Tabela = tabela;
            Frete = frete;
        }

        public double Calcula(Compra produto)
        {

            Tabela.DescontoPara(produto.Valor);
            double valorFrete = Frete.Para(produto.Cidade);
            Console.WriteLine(produto.Valor + valorFrete);
            return 0;
        }
    }

    class TabelaDePrecoPadrao : ITabela
    {
        public void DescontoPara(double valor)
        {
            Console.WriteLine("classe tabela de preco padrão acionada");

        }
    }

    class TabelaDePrecoPersonalizada : ITabela
    {
        public void DescontoPara(double valor)
        {
            Console.WriteLine("classe tabela de preco personalizada acionada");
        }
    }

    class FreteSp : IFrete
    {
        public double Para(string cidade)
        {

            if ("SAO PAULO".Equals(cidade.ToUpper()))
            {
                return 15;
            }
            return 30;
        }
    }

    class FreteRj : IFrete
    {
        public double Para(string cidade)
        {
            return 24;
        }
    }
}
