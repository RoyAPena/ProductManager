using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductManagerApi.Entities.Model
{
    public class Modelo
    {
        [Key]
        public int IdModelo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}