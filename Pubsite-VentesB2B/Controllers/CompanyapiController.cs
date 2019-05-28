using Pubsite_VentesB2B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pubsite_VentesB2B.Controllers
{
    public class CompanyapiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IHttpActionResult GetCompany()
        {
            return Ok(db.Companies.ToList());
        }
        public IHttpActionResult GetCompany(int id)
        {
            Company company = db.Companies.Find(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }
    }
}
