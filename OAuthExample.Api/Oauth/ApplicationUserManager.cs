using Microsoft.AspNet.Identity;
using OAuthExample.Api.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuthExample.Api.Oauth
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store) : base(store)
        {
        }
    }
}