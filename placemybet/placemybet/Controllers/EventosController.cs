using placemybet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace placemybet.Controllers
{
    public class EventosController : ApiController
    {
        //// GET: api/Eventos
        //public IEnumerable<eventos> Get()
        //{
        //    var repo = new eventosRepository();
        //    List<eventos> evento = repo.retrieve();
        //    //List<EventosDTO> evento = repo.retrieveDTO();
        //    return evento;
        //}

        //SEGUNDA PREGUNTA DEL EXAMEN

        internal List<eventos> retrieve(string nombreEquipo)
        {

            List<eventos> evento = new List<eventos>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                //apuesta = context.apuestas.ToList();
                //apuesta = context.apuestas.Include(p => p.usuario).ToList();//con esto inluimos la info de apuestas y ademas la de mercados
                context.evento.Include(p => p.ID).ToList();
                context.apuesta.Include(p => p.MercadoID).ToList();
                context.apuesta.Where(p => p.equipoLocal == nombreEquipo || p.equpoVisitante == nombreEquipo);
                evento = context.evento.Include(p => p.apostado).Include(b => b.mercado).ToList();

            }
            //Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetDecimal(2) + " " + res.GetDecimal(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetInt32(6));
            //d = new apuestas(res.GetInt32(0), res.GetString(1), res.GetDecimal(2), res.GetDecimal(3), res.GetString(4), res.GetInt32(5), res.GetInt32(6));
            //apuesta.Add(d);

            return evento;
        }

        //GET: api/Eventos
        public IEnumerable<EventosDTO> Get()
        {

            var repo = new eventosRepository();
            //List<eventos> evento = repo.retrieve();
            //eventos e = evento[0];
            List<EventosDTO> eventoDTO = repo.retrieveDTO();
            return eventoDTO; /*return EventoDTO;*/
        }


        //// GET: api/Eventos?ID_eventos=ID_eventos
        //public IEnumerable<MercadosDTO> Getevento(int ID_eventos) // metodo xa mostrar los mercados vinculados a la id de eventos
        //{
        //    //var repo = new eventosRepository();
        //    ////List<eventos> evento = repo.retrieve();
        //    //List<MercadosDTO> mercado = repo.retrieveByIDEvento(ID_eventos);
        //    return null;
        //}

        // GET: api/Eventos/5
        public eventos Get(int id)
        {
            /*var repo = new eventosRepository();
            eventos d = repo.retrieve();*/
            return null;
        }

        // POST: api/Eventos
        public void Post([FromBody]eventos evento)
        {
            var repo = new eventosRepository();
            repo.save(evento);
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]eventos evento)
        {
            var repo = new eventosRepository();
            repo.save(evento);
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
            var repo = new eventosRepository();
            repo.delete(id);
            
        }
    }
}
