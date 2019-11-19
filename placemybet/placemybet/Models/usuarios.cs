using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class usuarios
    {
        [Key]
        public string correoID { get; set; }
        public int edad { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public List<cuentas> cuentas { get; set; }
        //public List<mercados> mercado { get; set; }

        public usuarios()
        {

        }

        public usuarios(string correo, int edad, string nombre, string apellido)
        {
            this.correoID = correo;
            this.edad = edad;
            this.nombre = nombre;
            this.apellido = apellido;
        }
    }
}