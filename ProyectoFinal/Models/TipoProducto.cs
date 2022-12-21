using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProyectoFinal.Models
{
    public partial class TipoProducto
    {

        public TipoProducto()
        {
            Productos = new HashSet<Producto>();
        }

        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Tipo")]
        public string Tipo { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
