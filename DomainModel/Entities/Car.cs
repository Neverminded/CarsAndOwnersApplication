using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication5.Models
{
    public class Car
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id_car { get; set; }
        

        [Display(Name = "Mark car")]
        public string Mark_car { get; set; }
       
        [Display(Name = "Model car")]
        public string Model_car { get; set; }


        [Display(Name = "Type car")]
        public string Type_car { get; set; }


        [Display(Name = "Price car")]
        public int Price_car { get; set; }


        [Display(Name = "Year of issue car")]
        public int Year_of_issue_car { get; set; }
        

         public virtual ICollection<Owner> OwnersCar { get; set; }
         public Car()
         {
             OwnersCar = new List<Owner>();
         }
    }
}