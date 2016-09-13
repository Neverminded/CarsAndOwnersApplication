using DomainModel.SQLSiteMapPath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication5.HTMLHelpers
{
    public static class SiteMapHelper
    {
        public static MvcHtmlString SiteMap(this HtmlHelper html,IEnumerable<MySiteMapNode> list)
        {

            TagBuilder TagDiv = new TagBuilder("div");
            TagDiv.AddCssClass("sitemap");
            foreach (var item in list)
            {
                if (item != list.Last())
                {
                    TagBuilder linkbuilder = new TagBuilder("a");
                    linkbuilder.InnerHtml = item.NameNode;
                    linkbuilder.MergeAttribute("style", "color:white");
                    linkbuilder.MergeAttribute("href", "/" + item.NodeUrl);
                    TagDiv.InnerHtml += linkbuilder.ToString();
                    TagBuilder decoration = new TagBuilder("span");
                    decoration.MergeAttribute("style", "color:white");
                    decoration.InnerHtml = "-> ";
                    TagDiv.InnerHtml += decoration;
                }
                else {

                    TagBuilder labelbuilder = new TagBuilder("span");
                    labelbuilder.InnerHtml = item.NameNode;
                    labelbuilder.MergeAttribute("style","color:blue");
                   
                    TagDiv.InnerHtml += labelbuilder.ToString();
                    
                }
                
            }
            return new MvcHtmlString(TagDiv.ToString());
        }



    }
}