using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BlogSingle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string Date { get; set; }

        public string ByPerson { get; set; }

        public string Note { get; set; }

        public string ByPersonNote { get; set; }

    }
}