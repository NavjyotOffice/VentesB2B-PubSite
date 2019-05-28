using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Runtime.Serialization;
using System.Web;

namespace Pubsite_VentesB2B.Models
{
    [Table("Company")]
    public partial class Company
    {
        [Key]
        public int CompanyID { get; set; }

        [StringLength(1000)]
        public string CompanyName { get; set; }

        public string Description { get; set; }

        [StringLength(1000)]
        [DataType(DataType.Url)]
        public string WebsiteURL { get; set; }

        [StringLength(1000)]
        public string LogoImage { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ApplicationUser CreatedBy { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ApplicationUser UpdatedBy { get; set; }

        public int? AddressID { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Address Address { get; set; }

        //Not Mapped are below
        [NotMapped]
        public HttpPostedFileBase Upload { get; set; }
    }
}
