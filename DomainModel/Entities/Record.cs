using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DomainModel.Entities
{
    public class Record
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id_record { get; set; }


        [Display(Name = "Title")]
        public string Title_record { get; set; }


        [Display(Name = "Text record")]
        public string Text_record { get; set; }


        [Display(Name = "Date publiching")]
        [DataType(DataType.Date)]
        public System.DateTime Date_publishing { get; set; }



    }
}
