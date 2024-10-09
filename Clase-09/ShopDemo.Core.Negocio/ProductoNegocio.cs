using ShopDemo.Core.Datos;
using ShopDemo.Core.Entidades;

namespace ShopDemo.Core.Negocio
{
    public class ProductoNegocio
    {
        private ProductoRepository _productoRepository;

        public ProductoNegocio(ProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public List<Producto> Listado() { 
           
            return _productoRepository.Listado();
        }

    }
}
