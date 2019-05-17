using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Pubsite_VentesB2B.Models
{
    [Table("Contact")]
    public partial class Contact
    {
        public Contact()
        {
            Addresses = new HashSet<Address>();
        }

        public int ContactID { get; set; }

        [StringLength(1000)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
