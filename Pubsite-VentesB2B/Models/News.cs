using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Pubsite_VentesB2B.Models
{
    public enum NewsType { Featured, Trending }
    public partial class News
    {
        public int NewsID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? NewsDate { get; set; }

        public int? ContentID { get; set; }

        public virtual ContentDetail ContentDetail { get; set; }

        [Column("N_Type")]
        public string NewsType
        {
            get
            {
                return this.N_Type.ToString();
            }
            set
            {
                N_Type = value.ParseEnum<NewsType>();
            }
        }

        [NotMapped]
        public NewsType N_Type { get; set; }
    }

    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
