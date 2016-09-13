using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication5.Models
{
    public class Owner
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id_owner { get; set; }


        [Display(Name = " Name owner")]
        public string Name_owner { get; set; }


        [Display(Name = "Surname owner")]
        public string Surname_owner { get; set; }


        [Display(Name = "Birsday owner")]
        [DataType(DataType.Date)]
        public System.DateTime Birsday_owner { get; set; }



        [Display(Name = "Driving experience")]
        public int Driving_experience { get; set; }
       

         public virtual ICollection<Car> CarsOwner { get; set; }
         public Owner()
         {
             CarsOwner = new List<Car>();
         }


    }
}