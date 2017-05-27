using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Controllers
{
    public class ProjectController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Project/
        public ActionResult Index()
        {
            return View(db.Projects);
        }

        //
        // GET: /Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Project/Create
        public ActionResult Create()
        {
            List<User> managers = UsersList.getUsersByRole("manager");
            ProjectCreateModel model = new ProjectCreateModel
            {
                Managers = GetSelectListItems(managers)
            };
            return View(model);
        }

        //
        // POST: /Project/Create
        [HttpPost]
        public ActionResult Create(ProjectCreateModel model)
        {
            List<User> managers = UsersList.getUsersByRole("manager");
            model.Managers = GetSelectListItems(managers);
           
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

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<User> elements)
        {
            var selectList = new List<SelectListItem>();

            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id,
                    Text = element.UserName
                });
            }

            return selectList;
        }

    }
}
