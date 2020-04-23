using System;
using System.Collections.Generic;
using System.Text;

namespace solid
{
    class DezOuVintePorcento : IBonus
    {
        public double Calcular(Funcionario funcionario)
        {
            double r = 0;
            if (funcionario.SalarioBase > 3000.0)
            {
                r = funcionario.SalarioBase * 0.8;
            }
            else
            {
                r = funcionario.SalarioBase * 0.9;
            }
            Console.WriteLine(r);
            return r;
        }
    }

    class QuinzeOuVintePorcento : IBonus
    {
        public double Calcular(Funcionario funcionario)
        {
            double r = 0;
            if (funcionario.SalarioBase > 2000.0)
            {
                r = funcionario.SalarioBase * 0.75;
            }
            else
            {
                r = funcionario.SalarioBase * 0.85;
            }
            Console.WriteLine(r);
            return r;
        }
    }

    public interface IBonus
    {
        public double Calcular(Funcionario funcionario);
    }
}
