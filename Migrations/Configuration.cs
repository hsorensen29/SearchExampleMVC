namespace SearchExampleMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SearchExampleMVC.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SearchExampleMVC.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Categories.AddOrUpdate(
              p => p.Id,
              new Models.Category { Id = 1, Name = "Shoes" },
              new Models.Category { Id = 2, Name = "Cars" },
              new Models.Category { Id = 3, Name = "Dragons" },
              new Models.Category { Id = 4, Name = "Wars" },
              new Models.Category { Id = 5, Name = "Projects" },
              new Models.Category { Id = 6, Name = "Masters" }
            );
            context.Products.AddOrUpdate(
                  p => p.Id,
                  new Models.Product { Id = 1, Name = "Awesome shoes", Description = "These shoes are pretty good" },
                  new Models.Product { Id = 2, Name = "Terrible slacks", Description = "This shoe sux" },
                  new Models.Product { Id = 3, Name = "total recall", Description = "Best movie ever" },
                  new Models.Product { Id = 4, Name = "Star wars", Description = "Super movie" },
                  new Models.Product { Id = 5, Name = "Projects", Description = "best project in the world" },
                  new Models.Product { Id = 6, Name = "Masters", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." }
                );
            context.NewsPosts.AddOrUpdate(
                 p => p.Id,
                 new Models.NewsPost { Id = 1, Name = "we got a new warrior", Content = "The biggest soldier in the world is here" },
                 new Models.NewsPost { Id = 2, Name = "Cars", Content = "adawdafasdaj gfa sjdnfsejf wkef" },
                 new Models.NewsPost { Id = 3, Name = "Dragons", Content = "joefjksdfwjkefweno wofn oefwiefwoefw fwefwefw" },
                 new Models.NewsPost { Id = 4, Name = "Wars", Content = "posdkas poakop efmoef mlasdmo o" },
                 new Models.NewsPost { Id = 5, Name = "Projects", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing" },
                 new Models.NewsPost { Id = 6, Name = "Masters", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing" }
);
        }
    }
}
