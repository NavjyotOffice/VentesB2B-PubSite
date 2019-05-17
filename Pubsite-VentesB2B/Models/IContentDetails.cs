using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pubsite_VentesB2B.Models
{
    interface IContentDetails
    {
        string Title { get; set; }
        string Description { get; set; }
        string Keywords { get; set; }
        string Author { get; set; }
        string Image { get; set; }
        string URL { get; set; }
        bool ShowOnSite { get; set; }
        DateTime? CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        string CreatedById { get; set; }
        string UpdatedById { get; set; }
        HttpPostedFileBase Upload { get; set; }
    }
}
