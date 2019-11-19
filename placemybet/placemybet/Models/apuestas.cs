using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class apuestas
    {
        public apuestas(int iD, string tipo, decimal cuota, decimal apostado, string correoID, int MercadoID, int esOver)
        {
            ID = iD;
            this.tipo = tipo;
            this.cuota = cuota;
            this.apostado = apostado;
            this.correoID = correoID;
            this.MercadoID = MercadoID;
            this.esOver = esOver;
        }

        public int ID { get; set; }
        public string tipo { get; set; }
        public decimal cuota { get; set; }
        public decimal apostado { get; set; }
        public string correoID { get; set; }
        public int MercadoID { get; set; }
        public int esOver { get; set; }
        public usuarios usuario { get; set; }
        public mercados mercado { get; set; }
        

        public apuestas()
        {

        }


    }

    public class ApuestasDTO
    {
        public ApuestasDTO(string tipo, decimal cuota, decimal apostado, string correo_usuario, int esOver)
        {
            this.tipo = tipo;
            this.cuota = cuota;
            this.apostado = apostado;
            this.correo_usuario = correo_usuario;
            this.esOver = esOver;
            
        }

        public string tipo { get; set; }
        public decimal cuota { get; set; }
        public decimal apostado { get; set; }
        public string correo_usuario { get; set; }
        public int esOver { get; set; }
        
    }

    public class ApuestaCorreo
    {
        public ApuestaCorreo(int evento, string tipoMercado, int esOver, double cuota, double apostado)
        {
            this.evento = evento;
            this.tipoMercado = tipoMercado;
            this.esOver = esOver;
            this.cuota = cuota;
            this.apostado = apostado;
        }

        public int evento { get; set; }
        public string tipoMercado { get; set; }
        public int esOver { get; set; }
        public double cuota { get; set; }
        public double apostado { get; set; }


    }

    public class apuestasExamen
    {
        public apuestasExamen(string tipo, decimal cuotaOver, decimal cuotaUnder)
        {
            this.tipo = tipo;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
        }

        public string tipo { get; set; }
        public decimal cuotaOver { get; set; }
        public decimal cuotaUnder { get; set; }
    }

}