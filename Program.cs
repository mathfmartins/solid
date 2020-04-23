using System;

namespace solid
{
    class Program
    {
        static void Main(string[] args)
        {
            Funcionario desenvolvedor = new Desenvolvedor(1000, new DezOuVintePorcento());
            Funcionario dba = new Dba(1000, new QuinzeOuVintePorcento());
            Funcionario publicitario = new Publicitario(1000, new DezOuVintePorcento());

            var calculadorDeSalario = new CalculadoraDeSalario();
            calculadorDeSalario.Calcula(desenvolvedor);
            calculadorDeSalario.Calcula(dba);
            calculadorDeSalario.Calcula(publicitario);


            //Inversão de dependência

            var compra = new Compra()
            {
                Cidade = "São Paulo",
                Valor = 1000
            };

            var calculadorDePrecos1 = new CalculadoraDePrecos(new TabelaDePrecoPadrao(), new FreteSp());
            calculadorDePrecos1.Calcula(compra);

            calculadorDePrecos1 = new CalculadoraDePrecos(new TabelaDePrecoPersonalizada(), new FreteRj());
            calculadorDePrecos1.Calcula(compra);
            
        }
    }


    public class CalculadoraDeSalario
    {
        public void Calcula(Funcionario funcionario)
        {
            funcionario.Bonus.Calcular(funcionario);
        }
    }


    public class Funcionario 
    {
        public IBonus Bonus { get; set; }

        public double SalarioBase { get; private set; }

        public Funcionario(double salarioBase, IBonus bonus)
        {
            Bonus = bonus;
            SalarioBase = salarioBase;
        }

        public double Calcular(Funcionario funcionario)
        {
            return 0;
        }
    }

    public class Desenvolvedor : Funcionario
    {
        public Desenvolvedor(double salarioBase, IBonus bonus) : base(salarioBase, bonus)
        {
        }
    }

    public class Dba : Funcionario
    {
        public Dba(double salarioBase, IBonus bonus) : base(salarioBase, bonus) { }
       
    }

    public class Publicitario :  Funcionario
    {
        public Publicitario(double salarioBase, IBonus bonus) : base(salarioBase, bonus) { }
    }
}
