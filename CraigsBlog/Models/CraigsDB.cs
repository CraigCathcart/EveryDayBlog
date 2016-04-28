using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CraigsBlog.Models
{
    public class CraigsDB: DbContext  //inheriting CraigsDB from the DbContext
    {
        public CraigsDB()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CraigsDB>());
        }
        public DbSet<Users> craigsUsers { get; set; } //create the link between the model and the database, use slightly different name so as not to get confused.
        public DbSet<Blogs> craigsBlogs { get; set; }
        public DbSet<Keywords> craigsKeywords { get; set; }
    }
}