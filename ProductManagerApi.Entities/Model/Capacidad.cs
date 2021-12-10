using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductManagerApi.Entities.Model
{
    public class Capacidad
    {
        [Key]
        public int IdCapacidad { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<DetalleProducto> DetalleProducto { get; set; }
    }
}