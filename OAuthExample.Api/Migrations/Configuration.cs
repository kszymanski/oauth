using OAuthExample.Api.Entity;
using OAuthExample.Api.Models;

namespace OAuthExample.Api.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OAuthExample.Api.Entity.AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OAuthExample.Api.Entity.AuthContext context)
        {
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
            context.Clients.AddOrUpdate(
                    new Client() {Id="JsApp", Secret = "thatShouldBeHash", Active = true, AllowedOrigin = "*", ApplicationType = ApplicationTypes.JavaScript, Name = "ClientApp", RefreshTokenLifeTime = 36000}
                );   
        }
    }
}
