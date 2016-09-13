using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication5.Models
{
    public class EditOwnerViewModel
    {
        
        public Owner Owner { get; set; }
        public List<Car> Unassigned_cars { get; set; }
        
    }
}