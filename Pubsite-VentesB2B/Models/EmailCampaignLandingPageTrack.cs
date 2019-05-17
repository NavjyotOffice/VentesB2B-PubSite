using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pubsite_VentesB2B.Models
{
    public class EmailCampaignLandingPageTrack
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }
        public string Revenue { get; set; }
        public string EmployeeSize { get; set; }
        public string Industry { get; set; }
        public string IP { get; set; }
        public string Browser { get; set; }
        public string Device { get; set; }
        public DateTime DateTime { get; set; }
        public string CampaignName { get; set; }
        public string Track { get; set; }
        public Nullable<bool> OptIn { get; set; }
        public string CustomQuestion1 { get; set; }
        public string CustomQuestion2 { get; set; }
        public string CustomQuestion3 { get; set; }
        public string CustomQuestion4 { get; set; }
        public string CustomQuestion5 { get; set; }
    }
}