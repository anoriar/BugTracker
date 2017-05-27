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
           List<User> managers =UsersList.getUsersByRole("manager");
           if (managers.Count != 0)
           {
               ProjectCreateModel model = new ProjectCreateModel
               {
                   ManagerId = managers.FirstOrDefault().Id,
                   Managers = new SelectList(managers)
               };
               return View(model);
           }
           else
           {
               ViewData["Message"] = "В системе нет пользователей с ролью 'Менеджер'";
              
           }
           return View(new ProjectCreateModel());
           
        }

        //
        // POST: /Project/Create
        [HttpPost]
        public ActionResult Create(ProjectCreateModel model)
        {

            if (model.Managers.Count() == 0)
            {
                ModelState.AddModelError("Managers", "Менеджер не выбран");
            }
            if (ModelState.IsValid)
            {
                Project project = new Project
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    Customer = model.Customer,
                    ManagerId = model.ManagerId,
                    Manager = db.Users.Find(model.ManagerId)
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
