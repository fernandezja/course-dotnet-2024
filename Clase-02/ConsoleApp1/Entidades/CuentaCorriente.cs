using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    public class CuentaCorriente: CuentaBancaria
    {
      
       public override int Extraer(int valor)
        {
            if (Saldo - valor < -5000)
            {
                throw new Exception("No puede extraer mas de 5000");
            }

            return base.Extraer(valor);
        }
    }
}
