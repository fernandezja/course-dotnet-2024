using ShopDemo.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDemo.Core.Negocio
{
    public class Carrito
    {
        public List<CarritoItem> Items { get; set; }

        public Carrito()
        {
            Items = new List<CarritoItem>();
        }

        public void Agregar(int productoId)
        {
            var producto = new Producto
            {
                ProductoId = productoId,
                Nombre = $"Producto {productoId}",
                Precio = productoId * 1000.1
            };

            if (!Items.Any(p => p.Producto.ProductoId == productoId))
            {
                Items.Add(new CarritoItem
                {
                    Producto = producto,
                    Cantidad = 1
                });
            }
            else
            {
                var item = Items.First(p => p.Producto.ProductoId == productoId);
                item.Cantidad++;
            }



            return;
        }

        public int ItemsCantidadTotal
        {
            get {
                return Items.Sum(i => i.Cantidad);
            }
        }
    }
}
