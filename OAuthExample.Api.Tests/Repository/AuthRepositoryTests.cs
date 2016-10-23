using Autofac.Extras.Moq;
using Microsoft.AspNet.Identity;
using Moq;
using NUnit.Framework;
using OAuthExample.Api.Entity;
using OAuthExample.Api.Models;
using OAuthExample.Api.Oauth;
using OAuthExample.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuthExample.Api.Tests.Repository
{
    public class AuthRepositoryTests
    {
        [Test]
        public void RegisterUserTest()
        {
            var userStore = new Mock<IUserStore<User>>();
            var userManager = new Mock<ApplicationUserManager>(userStore.Object);

            userManager.Setup(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);

            var authContext = new Mock<AuthContext>() { CallBase = true };

            IAuthRepository sut = new AuthRepository(authContext.Object, userManager.Object);
            var user = new UserModel() { UserName = "test", Password = "asdf", ConfirmPassword = "asdf" };

            var result = sut.RegisterUser(user);
            result.Wait();

            userManager.Verify(mock => mock.CreateAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Once());
            Assert.That(result.Result.Succeeded, Is.True);
        }

        [Test]
        public void FindUserTest()
        {
            var userStore = new Mock<IUserStore<User>>();
            var userManager = new Mock<ApplicationUserManager>(userStore.Object);

            userManager.Setup(x => x.FindAsync("test", "test")).ReturnsAsync(new User() {UserName = "test"});
            var authContext = new Mock<AuthContext>() { CallBase = true };


            IAuthRepository sut = new AuthRepository(authContext.Object, userManager.Object);
            var user = new UserModel() { UserName = "test", Password = "asdf", ConfirmPassword = "asdf" };

            var result = sut.FindUser("test", "test");
            result.Wait();

            userManager.Verify(mock => mock.FindAsync("test", "test"), Times.Once());
            Assert.That(result.Result.UserName, Is.EqualTo("test"));
        }
    }
}
