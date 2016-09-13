using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication5.ViewModels
{
    public class RequestUsrViewModel
    {
        public RequestUser MinResponce { get; set; }
        public RequestUser MaxResponce { get; set; }
        public IEnumerable<RequestUser> TopSlowestPages { get; set; }
    }
}