using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OAuthExample.Api.Entity
{
    public class AuthContext : IdentityDbContext<User>
    {
        public AuthContext() : base() { }
        public AuthContext(string connectionString) : base(connectionString) {}

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}