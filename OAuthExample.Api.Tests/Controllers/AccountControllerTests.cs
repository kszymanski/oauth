using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using OAuthExample.Api.Controllers;
using OAuthExample.Api.Models;
using OAuthExample.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace OAuthExample.Api.Tests.Controllers
{
    class AccountControllerTests
    {
        [Test]
        public void RegisterUser()
        {
            var ctx = new Mock<IAuthRepository>();

            UserModel user = new UserModel() { UserName = "test", Password = "asdf", ConfirmPassword = "asdf" };

            ctx.Setup(x => x.RegisterUser(user)).ReturnsAsync(IdentityResult.Success);

            var ctrl = new AccountController(ctx.Object);

            var Result = ctrl.Register(user);
            Result.Wait();

            Assert.IsInstanceOf<OkResult>(Result.Result);
        }
    }
}
