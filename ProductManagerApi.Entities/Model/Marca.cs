using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductManagerApi.Entities.Model
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}