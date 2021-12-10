using ProductManagerApi.Entities.ViewModel;
using System.Collections.Generic;

namespace ProductManagerApi.Entities.Request.Producto
{
    public class InsertProductoRequest
    {
        public int? IdMarca { get; set; }
        public int? IdModelo { get; set; }
        public string Nombre { get; set; }

        public List<InsertDetalleProductoViewModel> DetalleProducto { get; set; }
    }
}
