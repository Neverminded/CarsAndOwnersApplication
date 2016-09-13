using MvcApplication5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.SQLSiteMapPath
{
    public class SiteMapBuilder
    {
        private DataContext context;
        private MySiteMapNode currentnode; 
        public MySiteMapNode CurrentNode { get; set; }
        
        public SiteMapBuilder(string currentnode)
        {
            context = new DataContext();
            this.currentnode = context.MyNodesCollection.First(n => n.NodeUrl.Equals(currentnode));
           
        }

        public List<MySiteMapNode> FindNodes(List<MySiteMapNode> coll, MySiteMapNode curr)
        {
            var fullcollection = context.MyNodesCollection.OrderBy(n => n.IdNode);
            if (curr.ParrentNodeId == 0)
            {
                coll.Add(curr);
            }
            else if (curr.ParrentNodeId != 0) {

                foreach (var item in fullcollection.ToList())
                {

                    if (curr.ParrentNodeId == item.IdNode)
                    {
                        coll.Add(curr);
                       
                        FindNodes(coll, item);
                    }
                }


            }

            return coll;
        }

        public List<MySiteMapNode> GetSiteMapPath()
        {
            List<MySiteMapNode> currentcollection = new List<MySiteMapNode>();

            return FindNodes(currentcollection, currentnode);


        }
    }
}
