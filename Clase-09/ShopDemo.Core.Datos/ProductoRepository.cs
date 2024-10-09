using ShopDemo.Core.Entidades;

namespace ShopDemo.Core.Datos
{
    public class ProductoRepository
    {
        public List<Producto> Listado()
        {
            var productos = new List<Producto>();

            for (int i = 1; i <= 10; i++)
            {
                productos.Add(new Producto
                {
                    ProductoId = i,
                    Nombre = $"Producto {i}",
                    Precio = i * 1000.1
                });
            }

            return productos;
        }
    }
}
