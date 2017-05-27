using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;


namespace BugTracker.Controllers
{
    public class ProjectController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Project/
        public ActionResult Index()
        {

            var projects = db.Projects.Include(p => p.Manager);
            return View(projects);
        }

        //
        // GET: /Project/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }

            var model = new ProjectDetailModel
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Customer = project.Customer,
                ManagerName = db.Users.Find(project.ManagerId).UserName,
                Issues = project.Issues.ToList()
            };

            return View(model);
        }

        //
        // GET: /Project/Create
        public ActionResult Create()
        {
            var managers = UsersList.getUsersByRole("manager");
            ProjectCreateModel model = new ProjectCreateModel
            {
                Managers = managers
            };
            return View(model);
        }

        //
        // POST: /Project/Create
        [HttpPost]
        public ActionResult Create(ProjectCreateModel model)
        {
            var managers = UsersList.getUsersByRole("manager");
            model.Managers = managers;
           
            if (ModelState.IsValid)
            {
                var manager = db.Users.Find(model.ManagerId);
                Project project = new Project
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    Customer = model.Customer,
                    ManagerId = manager.Id,
                    Manager = manager
                };
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(model);
        }

        //
        // GET: /Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
