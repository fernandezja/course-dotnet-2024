using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entidades
{
    public abstract  class CuentaBancaria
    {
        private int _saldo;
        public int Saldo
        {
            get
            {
                return _saldo;
            }

            private set
            {
               
                _saldo = value;
            }
        }

        //private string _titular;

        //public string Titular
        //{
        //    get { return _titular; }
        //    set { _titular = value; }
        //}

        public Persona Titular { get; set; }


        public void Depositar(int valor)
        {
            //_saldo += valor;
            Saldo += valor;
        }

        public virtual int Extraer(int valor)
        {
            Saldo -= valor;
            return valor;
        }
    }
}
