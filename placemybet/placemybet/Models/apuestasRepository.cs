using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace placemybet.Models
{
    public class apuestasRepository
    {

        //modicamos xa q nos devuelva todos los datos, del EJERCICIO 3
        internal List<apuestas> retrieve()
        {

            List<apuestas> apuesta = new List<apuestas>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                //apuesta = context.apuestas.ToList();
                //apuesta = context.apuestas.Include(p => p.usuario).ToList();//con esto inluimos la info de apuestas y ademas la de mercados
                apuesta = context.apuestas.Include(p => p.usuario).Include(p => p.mercado).ToList();

            }
            //Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetDecimal(2) + " " + res.GetDecimal(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetInt32(6));
            //d = new apuestas(res.GetInt32(0), res.GetString(1), res.GetDecimal(2), res.GetDecimal(3), res.GetString(4), res.GetInt32(5), res.GetInt32(6));
            //apuesta.Add(d);

            return apuesta;
        }
        /*Ahora, configura tu aplicaci´on para que cuando se recuperen todas las apuestas,
        se obtenga la siguiente informaci´on: el identificador del usuario, el identificador del
        evento, el tipo de apuesta, la cuota de la apuesta y el dinero de la apuesta.Para
        conseguir esto, a parte de hacer un DTO con esta informaci´on, deber´as utilizar el
        Include para recuperar el objeto mercado de cada apuesta*/
        //metodo xa mostrar datos del EJECICIO 3
        public apuestasExamen ToDTO(apuestas e)
        {
            return new apuestasExamen(e.usuario, e.cuotaOver, e.cuotaUnder);
        }

        public List<apuestasExamen> retrieveExamen()
        {
            List<apuestasExamen> apuestas = new List<apuestasExamen>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.apuestas.Select(p => ToDTO(p)).ToList();
            }
            return apuestas;
        }

        internal apuestas retrieve(int id)
        {
            apuestas apuesta;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuesta = context.apuestas
                    .Where(s => s.ID == id)
                    .FirstOrDefault();
            }
            return apuesta;
        }

        //metodo xa Post
        internal void save(apuestas d)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.apuestas.Add(d);
            context.SaveChanges();
        }

        //metodo actualizar cuotas
        //fin del futuro metodo de actualizar

        internal List<ApuestasDTO> retrieveDTO()
        {
            /*
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas";
            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            ApuestasDTO d = null;
            List<ApuestasDTO> apuesta = new List<ApuestasDTO>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetDecimal(2) + " " + res.GetDecimal(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetInt32(6));
                d = new ApuestasDTO(res.GetString(1), res.GetDecimal(2), res.GetDecimal(3), res.GetString(4), res.GetInt32(6));
                apuesta.Add(d);
            }

            con.Close();*/
            return null; //ponemos null pero originalmente era return apuestas;
        }

        /*internal void save(apuestas d)
        {
            
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            //command.CommandText = "insert into apuestas(tipo,cuota,apostado,correo_usuario,esOver) values ('"+ d.tipo + "','" + d.cuota + "','" + d.apostado + "','" + d.correo_usuario + "','" + d.esOver + "');";
            command.CommandText = "insert into apuestas(tipo,cuota,apostado,correo_usuario,ID_mercados,esOver) values ('" + d.tipo + "','" + d.cuota + "','" + d.apostado + "','" + d.correo_usuario + "','" + d.ID_mercados + "','" + d.esOver + "');";
            Debug.WriteLine("command " + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch(MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexion");
            }
        }*/

        /*internal List<ApuestaCorreo> retrieveCorreo(string correo)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT mercados.ID_eventos,apuestas.tipo,esOver,cuota,apostado FROM apuestas INNER JOIN mercados ON apuestas.ID_mercados = mercados.ID WHERE apuestas.correo_usuario = @correo";
            command.Parameters.AddWithValue("@correo", correo);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaCorreo d = null;
                List<ApuestaCorreo> apuesta = new List<ApuestaCorreo>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperando: "+ res.GetInt32(0)+ " " + res.GetString(1) + " " + res.GetInt32(2)  + " " + res.GetDouble(3) + " " + res.GetDouble(4));
                    d = new ApuestaCorreo(res.GetInt32(0), res.GetString(1), res.GetInt32(2), res.GetDouble(3), res.GetDouble(4));
                    apuesta.Add(d);
                }

                con.Close();
                return apuesta; //ponemos null pero originalmente era return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexion");
                return null;
            }
        }*/

        /*internal List<ApuestasDTO> cuotas()
        {
            int dineroOver = 0;
            int dineroUnder = 0;
            int probabilidadOver = 0;
            int probabilidadUnder = 0;
            List<ApuestasDTO> apuestas = new List<ApuestasDTO>();
            
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas";
            con.Open();
            MySqlDataReader res = command.ExecuteReader();

            ApuestasDTO d = null;
            List<ApuestasDTO> apuesta = new List<ApuestasDTO>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetDecimal(2) + " " + res.GetDecimal(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetInt32(6));
                d = new ApuestasDTO(res.GetString(1), res.GetDecimal(2), res.GetDecimal(3), res.GetString(4), res.GetInt32(6));
                apuesta.Add(d);
            }

            con.Close();
            foreach (ApuestasDTO item in apuesta)
            {
                if (item.esOver == 1)
                {
                    dineroOver = dineroOver + Convert.ToInt32(item.apostado);
                    probabilidadOver = dineroOver / (dineroOver + dineroUnder);
                }
                else
                {
                    dineroUnder = dineroUnder + Convert.ToInt32(item.apostado);
                    probabilidadUnder = dineroUnder / (dineroOver + dineroUnder);
                }
            }
            decimal cuotaOver = Convert.ToDecimal((1 / probabilidadOver) * 0.95);
            decimal cuotaUnder = Convert.ToDecimal((1 / probabilidadUnder) * 0.95);
            decimal[] valores = { cuotaOver , cuotaUnder };
            return valores;

            /*int dineroOver = 0;
            int dineroUnder = 0;
            int probabilidadOver = 0;
            int probabilidadUnder = 0;
            if (d.esOver == 1)
            {
                dineroOver = dineroOver + Convert.ToInt32(d.apostado);
                probabilidadOver = dineroOver / (dineroOver + dineroUnder);
            }
            else
            {
                dineroUnder = dineroUnder + Convert.ToInt32(d.apostado);
                probabilidadUnder = dineroUnder / (dineroOver + dineroUnder);
            }

            Double cuotaOver = (1 / probabilidadOver) * 0.95;
            Double cuotaUnder = (1 / probabilidadUnder) * 0.95;
            Convert.ToInt32(cuotaOver);

            return cuotaOver;

        }*/


    }
}