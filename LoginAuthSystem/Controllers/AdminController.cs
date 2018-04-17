using LoginAuthSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginAuthSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddRoles()
        {
            RolesModel rm = new RolesModel();
            return View(rm);
        }


        //Save New Roles
        [HttpPost]
        public ActionResult AddRoles(RolesModel rm)
        {
            if(ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    IdentityResult IdRoleResult;                    
                    var roleStore = new RoleStore<IdentityRole>(db);

                    var roleMgr = new RoleManager<IdentityRole>(roleStore);
                    
                    if (!roleMgr.RoleExists(rm.Name))
                    {
                        IdRoleResult = roleMgr.Create(new IdentityRole(rm.Name));
                        if (!IdRoleResult.Succeeded)
                        {
                            return View();
                        }
                        return RedirectToAction("AddRoles");
                    }
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddPost()
        {
            PostSetup ps = new PostSetup();
            return View(ps);
        }

        [HttpPost]
        public ActionResult AddPost(PostSetup ps)
        {
            if(ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    db.PostSetups.Add(ps);
                    db.SaveChanges();
                    return RedirectToAction("AddPost");
                }
            }
            return View(ps);
        }

        [HttpGet]
        public ActionResult EditPost(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var post = db.PostSetups.Single(x => x.ID == id);
                return View(post);
            }                
        }

        public ActionResult EditPost(PostSetup ps)
        {
            using (var db = new ApplicationDbContext())
            {
                if(ModelState.IsValid)
                {

                }
            }
                return View(ps);
        }

        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            var db = new ApplicationDbContext();
            var entity = db.PostSetups.Where(x => x.ID == id).FirstOrDefault();
            db.PostSetups.Remove(entity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PostDetails(int id)
        {
            return View();
        }
    }
}