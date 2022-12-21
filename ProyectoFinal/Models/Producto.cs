using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProyectoFinal.Models
{
    public partial class Producto
    {
        public Producto()
        {
            InventarioProductos = new HashSet<InventarioProducto>();
            ProductosFacturas = new HashSet<ProductosFactura>();
        }

        [Display(Name = "Código")]
        public int Id { get; set; }
        [Display(Name = "Producto")]
        public string NombreProducto { get; set; } = null!;
        [Display(Name = "Marca")]
        public string Marca { get; set; } = null!;
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }
        [Display(Name = "Precio")]
        public double Precio { get; set; }
        [Display(Name = "Tipo de Producto")]
        public int IdTipoProducto { get; set; }

        public virtual TipoProducto IdTipoProductoNavigation { get; set; } = null!;
        public virtual ICollection<InventarioProducto> InventarioProductos { get; set; }
        public virtual ICollection<ProductosFactura> ProductosFacturas { get; set; }
    }
}
