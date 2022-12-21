using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProyectoFinal.Models
{
    
    public partial class ProductosFactura
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }
        [Display(Name = "ID Factura")]
        public int IdFactura { get; set; }
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
