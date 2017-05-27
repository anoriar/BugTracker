using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BugTracker.Models;
using BugTracker.Models.Enums;

namespace BugTracker.Controllers
{
    public class IssueController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Issue/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = db.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }

            var enabledStatuses = EnabledStatuses.getEnabledIssueStatuses(issue.Status);
            var model = new IssueDetailModel
            {
                Id = issue.Id,
                Title = issue.Title,
                Description = issue.Description,
                Developer = db.Users.Find(issue.DeveloperId).UserName,
                Status = issue.Status.ToString(),
                Price = issue.Price,
                ProjectId = issue.ProjectId,
                EnabledStatuses = enabledStatuses
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Details")]
        public ActionResult ChangeStatus(IssueDetailModel model)
        {
            Issue issue = db.Issues.Find(model.Id);
           // var userName = issue.Developer.UserName;
           // if (User.Identity.Name == userName || User.IsInRole("manager") || User.IsInRole("admin"))
            //{
                if (ModelState.IsValid)
                {

                    issue.Status = (IssueStatuses)Enum.Parse(typeof(IssueStatuses), model.Status);
                    db.Entry(issue).State = EntityState.Modified;
                    db.SaveChanges();
                }
           // }
                model.Id = issue.Id;
                model.Title = issue.Title;
                model.Description = issue.Description;
                model.Price = issue.Price;
                model.ProjectId = issue.ProjectId;
                model.Status = issue.Status.ToString();
                model.Developer = db.Users.Find(issue.DeveloperId).UserName;
                model.EnabledStatuses = EnabledStatuses.getEnabledIssueStatuses(issue.Status);

                return View(model);
        }

        // GET: /Issue/Create/projectid
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var developers = UsersList.getUsersByRole("developer");
            var model = new IssueCreateModel()
            {
                ProjectId = (int)id,
                Developers = developers
            };
           
            return View(model);
        }

        // POST: /Issue/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IssueCreateModel model)
        {
            
            if (ModelState.IsValid)
            {
                var project = db.Projects.Find(model.ProjectId);
                var developer = db.Users.Find(model.DeveloperId);
              
                Issue issue = new Issue
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    Price = model.Price,
                    Status = IssueStatuses.Open, 
                    DeveloperId = developer.Id,
                    Developer = developer,
                    ProjectId = project.Id,
                    Project = project
                };

                db.Issues.Add(issue);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = issue.Id });
            }
            var developers = UsersList.getUsersByRole("developer");
            model.Developers = developers;

            return View(model);
        }

    }
}
