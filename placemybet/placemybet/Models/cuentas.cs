using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class cuentas
    {
        [Key]
        public int tarjetaId { get; set; }
        public int saldo { get; set; }
        public string banco { get; set; }

        public string correoID { get; set; } // clave ajena de usuarios
        public usuarios usuario { get; set; }

        public cuentas()
        {

        }

        public cuentas(int tarjetaId, int saldo, string banco, string correoID)
        {
            this.tarjetaId = tarjetaId;
            this.saldo = saldo;
            this.banco = banco;
            this.correoID = correoID;
        }
    }
}