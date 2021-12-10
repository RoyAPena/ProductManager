using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagerApi.Entities.Model
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public int? IdMarca { get; set; }
        public int? IdModelo { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("IdMarca")]
        public virtual Marca Marca { get; set; }
        [ForeignKey("IdModelo")]
        public virtual Modelo Modelo { get; set; }

        public virtual ICollection<DetalleProducto> DetalleProducto { get; set; }
    }
}