using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace placemybet.Models
{
    public class eventosRepository
    {
        

        internal List<eventos> retrieve()
        {
            
            List<eventos> evento = new List<eventos>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.eventos.ToList();
            }
            return evento; 
        }
        //metodo xa buscar x id
        internal eventos retrieve(int id)
        {
            eventos evento;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.eventos
                    .Where(s => s.EventosID == id)
                    .FirstOrDefault();
            }
            return evento;

        }

        //Xa metodo post
        internal void save(eventos d)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.eventos.Add(d);
            context.SaveChanges();
        }
        
        

        //convierte un objeto evento en uno enteo DTO
        public EventosDTO ToDTO(eventos e)
        { 
            return new EventosDTO(e.equipoLocal, e.equipoVisitante);
        }

        //METODO XA MOSTRAR LOS DATOS DESEADOS, EN ESTE CASO EL DTO 
        public List<EventosDTO> retrieveDTO()
        {
            List<EventosDTO> evento = new List<EventosDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.eventos.Select(p => ToDTO(p)).ToList();
            }
            return evento;
        }

        //metodo xa actualizar

        internal void update(int id, eventos evento)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            var updateEvento = context.eventos.FirstOrDefault(e => e.EventosID == id);
            updateEvento.equipoLocal = evento.equipoLocal;
            updateEvento.equipoVisitante = evento.equipoVisitante;
            context.SaveChanges();

        }

        //metodo xa borrar
        internal void delete (int id)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            var eliminarEvento = context.eventos.FirstOrDefault(e => e.EventosID == id);
            context.eventos.Remove(eliminarEvento);
            context.SaveChanges();

        }

        //metodo, podemos seleccionar todos los eventos y transformarlos a DTO
        //internal List<EventosDTO> todosEventos()
        //    {
        //        List<EventosDTO> evento = new List<EventosDTO>();
        //        using (PlaceMyBetContext context = new PlaceMyBetContext())
        //        {
        //            evento = context.eventos.Select(p => retrieveDTO(p)).ToList();
        //        }
        //        return evento;
        //    }

        //modificar un evento
        //internal eventos update(int id)
        //{
        //    eventos evento;
        //    using (PlaceMyBetContext context = new PlaceMyBetContext())
        //    {
        //        evento = context.eventos
        //            .Where(s => s.EventosID == id)
        //            .FirstOrDefault();
        //    }
        //    return evento;

        //}


        //internal List<EventosDTO> ToDTO(string equipoLocal, string equipoVisitante)
        //{
        //    List<EventosDTO> evento = new List<EventosDTO>();
        //    using (PlaceMyBetContext context = new PlaceMyBetContext()) {
        //        EventosDTO d = null;
        //        d = new EventosDTO(equipoLocal, equipoVisitante);
        //        evento.Add(d);
        //    }
        //    return evento;
        //}

        //internal List<EventosDTO> retrieveDTO()
        // {
        ////    MySqlConnection con = Connect();
        ////    MySqlCommand command = con.CreateCommand();
        ////    command.CommandText = "select * from eventos";

        ////    con.Open();
        ////    MySqlDataReader res = command.ExecuteReader();

        ////    EventosDTO d = null;
        ////    List<EventosDTO> evento = new List<EventosDTO>();
        ////    while (res.Read())
        ////    {
        ////        Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDateTime(1) + " " + res.GetString(2) + " " + res.GetString(3));
        ////        d = new EventosDTO(res.GetString(2), res.GetString(3));
        ////        evento.Add(d);
        ////    }

        ////    con.Close();
        //    //return null; //ponemos null pero originalmente era return evento;
        //}

        //internal List<MercadosDTO> retrieveByIDEvento(int ID_eventos)
        //{
        //    MySqlConnection con = Connect();
        //    MySqlCommand command = con.CreateCommand();
        //    command.CommandText = "select * from mercados where ID_eventos = @id";
        //    command.Parameters.AddWithValue("@id", ID_eventos);

        //    try
        //    {
        //        con.Open();
        //        MySqlDataReader res = command.ExecuteReader();

        //        MercadosDTO d = null;
        //        List<MercadosDTO> mercado = new List<MercadosDTO>();
        //        while (res.Read())
        //        {
        //            Debug.WriteLine("Recuperando: " + res.GetDecimal(1) + " " + res.GetDecimal(2) + " " + res.GetDecimal(3));
        //            d = new MercadosDTO(res.GetDecimal(1), res.GetDecimal(2), res.GetDecimal(3));
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