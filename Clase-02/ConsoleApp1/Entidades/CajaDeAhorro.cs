using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    public class CajaDeAhorro: CuentaBancaria
    {

        public override int Extraer(int valor)
        {
            if (Saldo - valor < 0)
            {
                throw new Exception("No puede extraer mas que el saldo");
            }
            return base.Extraer(valor);
        }
    }
}
