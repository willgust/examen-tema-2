using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;


namespace placemybet.Models
{
    public class mercadosRepository
    {
        

        internal List<mercados> retrieve()
            {

            List<mercados> mercado = new List<mercados>();
 
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {

                mercado = context.mercados.ToList();
                //mercado = context.mercados.Include(p => p.evento).ToList(); // con esto incluimos la info de mercados y ademas la de eventos

            }           
            return mercado; 
        }

        internal mercados retrieve(int id)
        {
            mercados mercado;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.mercados
                    .Where(s => s.MercadoID == id)
                    .FirstOrDefault();
            }
            return mercado;
        }

        //metodo Post
        internal void save(mercados d)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.mercados.Add(d);
            context.SaveChanges();
        }

        //convertimos un mercado en DTO 
        public MercadosDTO ToDTO(mercados e)
        {
            return new MercadosDTO(e.tipo, e.cuotaOver,e.cuotaUnder);
        }

        //metodo xa mostrar los datos deseados
        public List<MercadosDTO> retrieveDTO()
        {
            List<MercadosDTO> mercado = new List<MercadosDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.mercados.Select(p => ToDTO(p)).ToList();
            }
            return mercado;
        }



        //internal List<MercadosDTO> retrieveDTO()
        //{
        //    MySqlConnection con = Connect();
        //    MySqlCommand command = con.CreateCommand();
        //    command.CommandText = "select * from mercados";

        //    con.Open();
        //    MySqlDataReader res = command.ExecuteReader();

        //    MercadosDTO d = null;
        //    List<MercadosDTO> mercado = new List<MercadosDTO>();
        //    while (res.Read())
        //    {
        //        Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDecimal(1) + " " + res.GetDecimal(2) + " " + res.GetDecimal(3) + " " + res.GetDecimal(4) + " " + res.GetDecimal(5) + " " + res.GetInt32(6));
        //        d = new MercadosDTO( res.GetDecimal(1), res.GetDecimal(2), res.GetDecimal(3));
        //        mercado.Add(d);
        //    }

        //    con.Close();
        //    return mercado;
        //}

        //internal List<MercadoID> retrieveID(int ID)
        //{
        //    MySqlConnection con = Connect();
        //    MySqlCommand command = con.CreateCommand();
        //    command.CommandText = "SELECT apuestas.correo_usuario,mercados.tipo,apuestas.esOver,apuestas.cuota,apuestas.apostado FROM mercados INNER JOIN apuestas ON apuestas.ID_mercados=mercados.ID WHERE mercados.ID = @ID";
        //    command.Parameters.AddWithValue("@ID", ID);

        //    try
        //    {
        //        con.Open();
        //        MySqlDataReader res = command.ExecuteReader();

        //        MercadoID d = null;
        //        List<MercadoID> mercado = new List<MercadoID>();
        //        while (res.Read())
        //        {
        //            Debug.WriteLine("Recuperando: " + res.GetString(0) + " " + res.GetDecimal(1) + " " + res.GetInt32(2) + " " + res.GetDecimal(3) + " " + res.GetDecimal(4));
        //            d = new MercadoID(res.GetString(0), res.GetDecimal(1), res.GetInt32(2), res.GetDecimal(3), res.GetDecimal(4));
        //            mercado.Add(d);
        //        }

        //        con.Close();
        //        return mercado;
        //    }
        //    catch(MySqlException e)
        //    {
        //        Debug.WriteLine("se ha producido un error de conexion");
        //        return null;
        //    }
        //}

    }
}