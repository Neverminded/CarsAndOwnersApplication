using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DomainModel.SQLSiteMapPath
{
    public class MySiteMapNode
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int IdNode { get; set; }

        [Display(Name = "Name node")]
        public string NameNode { get; set; }

        [Display(Name = "Url node")]
        public string NodeUrl { get; set; }

        [Display(Name = "Parrent id node")]
        public int ParrentNodeId { get; set; }

    }
}
