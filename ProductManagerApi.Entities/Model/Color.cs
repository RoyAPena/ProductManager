using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProductManagerApi.Entities.Model
{
    public class Color
    {
        [Key]
        public int IdColor { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<DetalleProducto> DetalleProducto { get; set; }
    }
}