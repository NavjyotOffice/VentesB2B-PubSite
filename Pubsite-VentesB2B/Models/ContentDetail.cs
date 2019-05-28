using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI.WebControls;

namespace Pubsite_VentesB2B.Models
{
    public partial class ContentDetail
    {
        public ContentDetail()
        {
            Events = new HashSet<Event>();
            News = new HashSet<News>();
            Resources = new HashSet<Resource>();
            //CreatedBy = new ApplicationUser();
            //UpdatedBy = new ApplicationUser();
        }

        [Key]
        public int ContentID { get; set; }

        [StringLength(1000)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        [StringLength(1000)]
        public string Author { get; set; }

        [StringLength(1000)]
        public string Image { get; set; }

        [StringLength(1000)]
        [DataType(DataType.Url)]
        public string URL { get; set; }

        public string CompanyName { get; set; }

        public bool HideOnSite { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Event> Events { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<News> News { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Resource> Resources { get; set; }

        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ApplicationUser CreatedBy { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ApplicationUser UpdatedBy { get; set; }


        //Not Mapped are below
        [NotMapped]
        [JsonIgnore]
        [IgnoreDataMember]
        public HttpPostedFileBase Upload { get; set; }
    }
}
