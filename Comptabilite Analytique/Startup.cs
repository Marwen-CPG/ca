using AspNet.Identity.AdoNet;
using Comptabilite_Analytique.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Comptabilite_Analytique.Startup))]
namespace Comptabilite_Analytique
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            create();
        }

        private void create()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
             var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
             if (!roleManager.RoleExists("administrateur"))
             {
                 // first we create Admin rool  
                 var role = new IdentityRole();
                 role.Name = "administrateur";
                 roleManager.Create(role);
             }
                // creating Creating   role    
                if (!roleManager.RoleExists("operateur"))
                {
                    var role = new IdentityRole();
                    role.Name = "operateur";
                    roleManager.Create(role);

                }
                // creating Creating   role    
                if (!roleManager.RoleExists("utilisateur"))
                {
                    var  role = new IdentityRole();
                    role.Name = "utilisateur";
                    roleManager.Create(role);
                }

                //var result1 = UserManager.AddToRole(UserManager.FindByName("roottoor").Id, "administrateur");
            
        }


    }
}
