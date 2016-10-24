using Autofac;
using Autofac.Builder;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using OAuthExample.Api.Entity;
using OAuthExample.Api.Oauth;
using OAuthExample.Api.Repository;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(OAuthExample.Api.Startup))]
namespace OAuthExample.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ContainerBuilder builder = new ContainerBuilder();
            HttpConfiguration config = new HttpConfiguration();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<AuthRepository>().As<IAuthRepository>();
            builder.Register(c => new AuthContext("AuthContext")).As(typeof(AuthContext)).SingleInstance();
            builder.Register(c => new UserStore<User>(c.Resolve<AuthContext>()))
                 .As<IUserStore<User>>()
                 .SingleInstance();
            builder.RegisterType<ApplicationUserManager>().SingleInstance();
            builder.RegisterType<SimpleAuthorizationServerProvider>()
                .AsImplementedInterfaces<IOAuthAuthorizationServerProvider, ConcreteReflectionActivatorData>().SingleInstance();
            builder.RegisterType<SimpleRefreshTokenProvider>()
                .AsImplementedInterfaces<IAuthenticationTokenProvider, ConcreteReflectionActivatorData>().SingleInstance();
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            ConfigureOAuth(app, container);
            WebApiConfig.Register(config);
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app, IContainer container)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = container.Resolve<IOAuthAuthorizationServerProvider>(),
                RefreshTokenProvider = container.Resolve<IAuthenticationTokenProvider>()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
} 