using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BugTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using BugTracker.Models.ViewModels;

namespace BugTracker.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationContext bt = new ApplicationContext();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Project/
        public ActionResult Index()
        {
            return View(bt.Projects.ToList());
        }

        // GET: /Project/Details/5
        public ActionResult Details(int? id)
        {
          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = bt.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }

            var model = new ProjectViewModel
            {
                Id = id,
                Title = project.Title,
                Description = project.Description,
                Customer = project.Customer,
                Manager = project.Manager
               
            };
       
            model.Issues = project.Issues.ToList();

            Session["param"] = project.Id.ToString();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(ProjectViewModel model, string returnUrl)
        {
            Project project = bt.Projects.Find(model.Id);
            var managerName = project.Manager;
            if ((User.Identity.Name == managerName && User.IsInRole("manager")) || User.IsInRole("admin"))
            {
                return RedirectToAction( "Create", "Issue");
            }

            return RedirectToAction("Login", "Account");
            
        }


        // GET: /Project/Create
        public ActionResult Create()
        {
           
            SelectList managers = new SelectList(UsersList.getUsersByRole("manager"));
            ViewBag.Roles = managers;
            return View();
        }

        // POST: /Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var newProject = new Project
                {
                    Title = model.Title,
                    Description = model.Description,
                    Customer = model.Customer,
                    Manager = model.Manager,
                    Issues = new List<Issue>()
                    
                };
                bt.Projects.Add(newProject);
                bt.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

       
       
    }
}
