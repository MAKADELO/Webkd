using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webkd.Models
{
    public class ReporteProducto
    {
        public String nombreProveedor { get; set; }
        public String direccionProveedor { get; set; }
        public String telefonoProveedor { get; set; }
        public String nombreProducto { get; set; }
        public int PrecioProducto { get; set; }
    }
}