using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Pubsite_VentesB2B.Models;

namespace Pubsite_VentesB2B.Controllers
{
    public class LandingPageTrackController : ApiController
    {
        private ApplicationDbContext db;

        public HttpResponseMessage Get()
        {
            db = new ApplicationDbContext();
            return Request.CreateResponse(HttpStatusCode.OK, db.EmailCampaignLandingPageTracks);
        }
        public HttpResponseMessage Post(EmailCampaignLandingPageTrack emailCampaignTrack)
        {
            try
            {
                using (db = new ApplicationDbContext())
                {
                    emailCampaignTrack.IP = HttpContext.Current.Request.UserHostAddress;
                    emailCampaignTrack.Browser = HttpContext.Current.Request.Browser.Type;
                    emailCampaignTrack.Device = HttpContext.Current.Request.Browser.IsMobileDevice ? HttpContext.Current.Request.Browser.MobileDeviceManufacturer : HttpContext.Current.Request.Browser.Platform;
                    emailCampaignTrack.DateTime = DateTime.Now;

                    db.EmailCampaignLandingPageTracks.Add(emailCampaignTrack);
                    db.SaveChanges();

                    var ResponseMessage = Request.CreateResponse(HttpStatusCode.Created, emailCampaignTrack);
                    ResponseMessage.Headers.Location = new Uri(Request.RequestUri + emailCampaignTrack.Id.ToString());
                    if (emailCampaignTrack.Track.ToLower() == "pixel")
                    {
                        var response = Request.CreateResponse(HttpStatusCode.Moved);
                        response.Headers.Location = new Uri("../Images/pixel.png", uriKind:UriKind.Relative);
                        return response;
                    }
                    return ResponseMessage;
                }
            }
            catch(Exception Ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, Ex);
            }
        }
    }
}
