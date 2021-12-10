using ProductManagerApi.Entities.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagerApi.Entities.Model
{
    public class DetalleProducto
    {
        [Key]
        public int IdDetalleProducto { get; set; }
        public int IdProducto { get; set; }
        public int IdColor { get; set; }
        public int IdCapacidad { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public byte[] Imagen { get; set; }
    
        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }
        [ForeignKey("IdColor")]
        public virtual Color Color { get; set; }
        [ForeignKey("IdCapacidad")]
        public virtual Capacidad Capacidad { get; set; }
    }
}