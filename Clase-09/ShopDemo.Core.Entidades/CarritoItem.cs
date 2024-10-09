using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDemo.Core.Entidades
{
    public class CarritoItem
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public double Subtotal
        {
            get
            {
                return Producto.Precio * Cantidad;
            }
        }
    }
}
