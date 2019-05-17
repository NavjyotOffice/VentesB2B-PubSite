using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Pubsite_VentesB2B.Models
{
    public enum EventType { Conference, OnDemand, Live }

    [Table("Event")]
    public partial class Event
    {
        public int EventID { get; set; }

        public int? AddressID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? EndDate { get; set; }

        public int? ContentID { get; set; }

        public virtual Address Address { get; set; }

        public virtual ContentDetail ContentDetail { get; set; }

        public string EventType
        {
            get
            {
                return this.E_Type.ToString();
            }
            set
            {
                E_Type = value.ParseEnum<EventType>();
            }
        }

        [NotMapped]
        public EventType E_Type { get; set; }
    }
}
