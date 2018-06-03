namespace AplicacionGestionEMS.Migrations
{
    using System;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AplicacionGestionEMS.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AplicacionGestionEMS.Models.ApplicationDbContext context)
        {
            string rolAdmin = "tipoAdmin";
            string rolProfesor = "tipoProfesor";
            string rolAlumno = "tipoAlumno";
            AddRole(context, rolAdmin);
            AddRole(context, rolProfesor);
            AddRole(context, rolAlumno);
            AddUser(context, "xxxxxxx", "xxxxxxx", "xx@upm.es", rolAdmin);
            AddUser(context, "Jessica", "apellidos", "yesica.diaz@upm.es", rolProfesor);
            AddUser(context, "Carolina", " apellidos ", "carolina.gallardop@upm.es", rolProfesor);
            AddUser(context, "ficitio1", " apellidos ", "ficticio1@alumnos.upm.es", rolAlumno);
            AddUser(context, "ficitio2", " apellidos ", "ficticio2@alumnos.upm.es", rolAlumno);
            AddUser(context, "ficitio3", " apellidos ", "ficticio3@alumnos.upm.es", rolAlumno);

        }

        public void AddRole(ApplicationDbContext context, String role)
        {
            IdentityResult IdRoleResult;
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            if (!roleMgr.RoleExists(role))
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = role });
        }
        public void AddUser(ApplicationDbContext context, String name, String surname, String email, String role)
        {
            IdentityResult IdUserResult;
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                Name = name,
                Surname = surname,
                UserName = email,
                Email = email,
            };
            IdUserResult = userMgr.Create(appUser, "123456Aa!");
            //asociar usuario con rol
            if (!userMgr.IsInRole(userMgr.FindByEmail(email).Id, role))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(email).Id, role);
            }
        }
    }
}
