using LoginAuthSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginAuthSystem.Logic
{
    internal class RoleActions
    {
        internal void createAdmin()
        {
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, you create the "Admin" role if it doesn't already exist. 

            if (!roleMgr.RoleExists("Admin"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole("Admin"));
                if (!IdRoleResult.Succeeded)
                {
                    // Do something if an error occurs, such as display a message
                }
            }

            // Create a User object based on the UserStore object and the ApplicationDbContext  
            // object. 

            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser()
            {
                UserName = "Admin",
            };
            IdUserResult = userMgr.Create(appUser, "Pa$$word");

            // If the new "Admin" user was successfully created, 
            // add the "Admin" user to the "Administrators" role. 
            if (IdUserResult.Succeeded)
            {
                IdUserResult = userMgr.AddToRole(appUser.Id, "Admin");
                if (!IdUserResult.Succeeded)
                {
                    // do something if user cannot be added to role, we will not handle that now.
                }
            }
            else
            {
                // Handle the error condition if there's a problem creating the new user. 
            }

        }

        internal void CreateUsers()
        {
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            //IdentityResult IdUserResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, you create the "User" role if it doesn't already exist. 

            if (!roleMgr.RoleExists("User1"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole("User1"));
                if (!IdRoleResult.Succeeded)
                {
                    // Handle the error condition if there's a problem creating the RoleManager object.
                }
            }

            //we will add new users to this role automatically, only administrators can create other administrators
        }
    }
}