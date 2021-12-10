using System.Collections.Generic;

namespace ProductManagerApi.Entities.ViewModel
{
    public class ProductoViewModel
    {
        public int IdProducto { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public List<DetalleProductoViewModel> DetalleProducto { get; set; }
    }
}