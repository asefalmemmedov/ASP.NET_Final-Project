using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ModelCategory
    {
        public ModelCategory()
        {
            OurModels = new HashSet<OurModel>();

        }
        public  int Id { get; set; }
        public string Name { get; set; }

        public ICollection<OurModel> OurModels { get; set; }




    }
}