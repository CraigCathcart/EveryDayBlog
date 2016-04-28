namespace CraigsBlog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CraigsBlog.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CraigsBlog.Models.CraigsDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CraigsBlog.Models.CraigsDB";
        }

        protected override void Seed(CraigsBlog.Models.CraigsDB context)
        {
            context.craigsUsers.AddOrUpdate(x => x.Id,
                new Users() { Id = 1, Email = "admin@admin.com", Password = "password", Name = "Admin", IsAuthorised = true }
                );
            context.craigsBlogs.AddOrUpdate(x => x.Id,
                new Blogs()
                {
                    Id = 1,
                    Title = "Apple",
                    Content = "Apple Inc. is an American multinational technology company headquartered in Cupertino, California, that designs, develops, and sells consumer electronics, computer software, and online services.",
                    Keywords = "apple, tech, iphone, macbook, Steve",
                    IsPublic = true
                },
                new Blogs() { Id = 2, Title = "Google", Content = "Google is one of the biggest thech companies in the world", Keywords = "google, chrome, domination", IsPublic = true },
                new Blogs() { Id = 3, Title = "Amazon", Content = "The company was founded in 1994, spurred by what Bezos called his regret minimization framework, which described his efforts to fend off any regrets for not participating sooner in the Internet business boom during that time. In 1994, Bezos left his employment as vice-president of D. E. Shaw & Co., a Wall Street firm, and moved to Seattle. He began to work on a business plan for what would eventually become Amazon.com.", Keywords = "amazon, kindle, shipping", IsPublic = true });
            
            context.craigsKeywords.AddOrUpdate(x => x.Id,
                new Keywords() { Id = 1, Keyword = "iphone" },
                new Keywords() {  Id = 2, Keyword = "computer"},
                new Keywords() {  Id = 3, Keyword = "Macbook"},
                new Keywords() {  Id = 4, Keyword = "tech"}
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }


    }
}
