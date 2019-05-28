using Pubsite_VentesB2B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pubsite_VentesB2B.Controllers
{
    public class ResourcesapiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IHttpActionResult GetResource()
        {
            return Ok(db.Resources.ToList());
        }
        public IHttpActionResult GetResource(int id)
        {
            Resource resources = db.Resources.Find(id);

            if (resources == null)
            {
                return NotFound();
            }

            return Ok(resources);
        }
    }
}
