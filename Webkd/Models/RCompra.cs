using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webkd.Models
{
    public class RCompra
    {
        public String Nombrecliente { get; set; }
        public String  Documentocliente{ get; set; }
        public String Emailcliente { get; set; }
        public int Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}