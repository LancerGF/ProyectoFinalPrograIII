using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProyectoFinal.Models
{
    
    public partial class InventarioProducto
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }
        [Display(Name = "Cantidad Disponible")]
        public int CantidadDisponible { get; set; }

        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
