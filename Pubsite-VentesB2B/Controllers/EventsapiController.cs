using Pubsite_VentesB2B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pubsite_VentesB2B.Controllers
{
    public class EventsapiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IHttpActionResult GetEvent()
        {
            return Ok(db.Events.ToList());
        }
        public IHttpActionResult GetEvent(int id)
        {
            Event events = db.Events.Find(id);
            if (events == null)
            {
                return NotFound();
            }

            return Ok(events);
        }
    }
}
