namespace Kino_tasemetöö.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Kino_tasemetöö.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Kino_tasemetöö.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Kino_tasemetöö.Models.ApplicationDbContext";
        }

        protected override void Seed(Kino_tasemetöö.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admins"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admins" };
                manager.Create(role);
            }
            if (!context.Users.Any
            (r => r.UserName == "kristoferviikmaa@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName =
                    "kristoferviikmaa@gmail.com",
                    Email =
                    "kristoferviikmaa@gmail.com",

                };
                manager.Create(user, "Parool11.");
                manager.AddToRole(user.Id, "Admins");
            }
        }
    }
}

