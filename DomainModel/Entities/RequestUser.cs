using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DomainModel.Entities
{
    public class RequestUser
    {
        [Key]
        [HiddenInput(DisplayValue = false)]

        public int IdRequest { get; set; }

        [Display(Name = "Path to page")]
        public string PathToPage { get; set; }


        [Display(Name = "Title page")]
        public string TitlePage { get; set; }

        
        [Display(Name = "Date request")]
        public DateTime DateRequest { get; set; }


        [Display(Name = "Responce time")]
        public double ResponceTime { get; set; }


        [Display(Name = "Ip user")]
        public string IpUser { get; set; }

        [Display(Name = "Browser user")]
        public string Browser { get; set; }

        [Display(Name = "Status code")]
        public string StatusCode { get; set; }

    }
}
