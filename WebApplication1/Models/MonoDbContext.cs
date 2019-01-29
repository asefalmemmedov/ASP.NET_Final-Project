using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class MonoDbContext:DbContext
    {
        public MonoDbContext() : base("MyDb") { }

        public DbSet<ProjectModel> ProjectModels { get; set; }
        public DbSet<OurModel> OurModels { get; set; }
        public DbSet<ModelCategory> ModelCategories { get; set; }
        public DbSet<BlogSingle> BlogModels { get; set; }   
        public DbSet<CastingModel> CastingModels { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Blog>  Blogs{ get; set; }
    }
}