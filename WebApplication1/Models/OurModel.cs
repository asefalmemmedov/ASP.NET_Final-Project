using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class OurModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public string Profession { get; set; }

        public string Photo { get; set; }

        public string HoverPhoto { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Instagram { get; set; }

        public string Youtube { get; set; }

        public string TopModel { get; set; }

        public int ModelCategoryId { get; set; }
        public ModelCategory ModelCategory { get; set; }

    }
}
