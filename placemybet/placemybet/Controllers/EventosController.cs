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
