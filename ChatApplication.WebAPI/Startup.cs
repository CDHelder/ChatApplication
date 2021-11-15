using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ChatApplication.WebAPI.Startup))]

namespace ChatApplication.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

        }
    }
}
