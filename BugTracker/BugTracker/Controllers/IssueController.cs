using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BugTracker.Models;
using BugTracker.Models.ViewModels;
using BugTracker.Models.Enums;

namespace BugTracker.Controllers
{
    public class IssueController : Controller
    {
        private ApplicationContext bt = new ApplicationContext();
        private ApplicationDbContext db = new ApplicationDbContext();

      
        // GET: /Issue/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = bt.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }

            var model = new IssueViewModel
            {
                Id = id,
                Title = issue.Title,
                Description = issue.Description,
                User = issue.UserName,
                Status = issue.Status.ToString(),
                Price = issue.Price.ToString()
            };

            SelectList statuses = new SelectList(EnabledStatuses.getEnabledIssueStatuses(model.Status));
            ViewBag.Statuses = statuses;

            return View(model);
        }


        // POST: /Issue/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(IssueViewModel model)
        {
            Issue issue = bt.Issues.Find(model.Id);
            var userName = issue.UserName;
            if (User.Identity.Name == userName || User.IsInRole("manager") || User.IsInRole("admin"))
            {
                if (ModelState.IsValid)
                {
                
                    issue.Status = (IssueStatuses)Enum.Parse(typeof(IssueStatuses), model.Status);
                    bt.Entry(issue).State = EntityState.Modified;
                    bt.SaveChanges();
                    return RedirectToAction("Details/" + model.Id);
                }
            }
            return RedirectToAction("Login", "Account");
        }

        // GET: /Issue/Create
        public ActionResult Create()
        {
            SelectList developers = new SelectList(UsersList.getUsersByRole("developer"));
            ViewBag.Roles = developers;
            return View();
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
                User user = db.Users.Where(b => b.UserName == model.User).FirstOrDefault();
                int lastNum = calcLastNum(bt.Issues.Select(b => b.Number).ToList());
                int projectId = Int32.Parse(Session["param"].ToString());
                Project project = bt.Projects.Find(projectId);
                var newIssue = new Issue
                {
                    Number = lastNum + 1,
                    Title = model.Title,
                    Description = model.Description,
                    Status = Models.Enums.IssueStatuses.Open,
                    UserId = user.Id.ToString(),
                    UserName = user.UserName,
                    Price = Decimal.Parse(model.Price),
                    ProjectId = projectId

                };
                project.Issues.Add(newIssue);
                bt.Issues.Add(newIssue);
                bt.SaveChanges();

                string redir = "Details/" + (lastNum + 1);
                return RedirectToAction(redir);
            }
      
            return View(model);
        }

        public int calcLastNum(List<int> nums){
            List<int> numbers = nums;
            int max = 0;
            foreach (int element in numbers)
            {
                if (max < element)
                {
                    max = element;
                }
            }
            return max;
        }

        // GET: /Issue/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Issue issue = bt.Issues.Find(id);
            if (issue == null)
            {
                return HttpNotFound();
            }

            var model = new IssueViewModel
            {
                Id = id,
                Title = issue.Title,
                Description = issue.Description,
                User = issue.UserName,
                Price = issue.Price.ToString()
            };

            SelectList developers = new SelectList(UsersList.getUsersByRole("developer"));
            ViewBag.Roles = developers;

            return View(model);
        }

        // POST: /Issue/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IssueViewModel model)
        {
            if (ModelState.IsValid)
            {
             
                Issue issue = bt.Issues.Find(model.Id);
                issue.Title = model.Title;
                issue.Description = model.Description;
                issue.UserName = model.User;
                issue.Price = Decimal.Parse(model.Price);
                bt.Entry(issue).State = EntityState.Modified;
                bt.SaveChanges();
                return RedirectToAction("Details/" + model.Id);
            }
            return View();
        }

       
    }
}
