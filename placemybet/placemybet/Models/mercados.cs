using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class mercados
    {
        public mercados(int iD, decimal tipo, decimal cuotaOver, decimal cuotaUnder, decimal apostadoOver, decimal apostadoUnder, int iD_eventos)
        {
            MercadoID = iD;
            this.tipo = tipo;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.apostadoOver = apostadoOver;
            this.apostadoUnder = apostadoUnder;
            EventosID = iD_eventos;
        }
        [Key]
        public int MercadoID { get; set; }
        public decimal tipo { get; set; }
        public decimal cuotaOver { get; set; }
        public decimal cuotaUnder { get; set; }
        public decimal apostadoOver { get; set; }
        public decimal apostadoUnder { get; set; }
        
        public List<apuestas> apuesta { get; set; }
        public int EventosID { get; set; }//entidad dependiente de la reclaciona
        public eventos evento { get; set; }

        public mercados()
        {

        }

        //public mercados(int mercadoID, decimal tipo, decimal cuotaOver, decimal cuotaUnder, decimal apostadoOver, decimal apostadoUnder, List<apuestas> apuesta, int eventosID, eventos evento)
        //{
        //    MercadoID = mercadoID;
        //    this.tipo = tipo;
        //    this.cuotaOver = cuotaOver;
        //    this.cuotaUnder = cuotaUnder;
        //    this.apostadoOver = apostadoOver;
        //    this.apostadoUnder = apostadoUnder;
        //    this.apuesta = apuesta;
        //    EventosID = eventosID;
        //    this.evento = evento;
        //}
    }

    public class MercadosDTO
    {
        public MercadosDTO(decimal tipo, decimal cuotaOver, decimal cuotaUnder)
        {
            
            this.tipo = tipo;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            
        }

        
        public decimal tipo { get; set; }
        public decimal cuotaOver { get; set; }
        public decimal cuotaUnder { get; set; }
       
    }

    public class MercadoID
    {
        public MercadoID(string correo, decimal tipo, int esOver, decimal cuota, decimal apostados)
        {
            this.correo = correo;
            this.tipo = tipo;
            this.esOver = esOver;
            this.cuota = cuota;
            this.apostados = apostados;
        }

        public string correo { get; set; }
        public decimal tipo { get; set; }
        public int esOver { get; set; }
        public decimal cuota { get; set; }
        public decimal apostados { get; set; }
    }
}
