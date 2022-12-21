using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProyectoFinal.Models
{
    
    public partial class Factura
    {
        
        public Factura()
        {
            ProductosFacturas = new HashSet<ProductosFactura>();
        }

        [Display(Name = "ID Factura")]
        public int Id { get; set; }
        [Display(Name = "Fecha de Compra")]
        public DateTime FechaCompra { get; set; }
        [Display(Name = "Cédula")]
        public int IdCliente { get; set; }
        [Display(Name = "Monto")]
        public double MontoTotal { get; set; }

        public virtual ICollection<ProductosFactura> ProductosFacturas { get; set; }
    }
}
