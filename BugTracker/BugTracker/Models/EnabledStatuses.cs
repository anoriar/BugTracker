using BugTracker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Models
{
    public class EnabledStatuses
    {
        public static IEnumerable<SelectListItem> getEnabledIssueStatuses(IssueStatuses status)
        {
       
            List<IssueStatuses> enabledStatuses = new List<IssueStatuses>();
            if (status == IssueStatuses.Open)
            {
                enabledStatuses.Add(IssueStatuses.Open);
                enabledStatuses.Add(IssueStatuses.CodeReview);
                enabledStatuses.Add(IssueStatuses.Closed);
            }

            if (status == IssueStatuses.CodeReview)
            {
                enabledStatuses.Add(IssueStatuses.CodeReview);
                enabledStatuses.Add(IssueStatuses.ReOpened);
                enabledStatuses.Add(IssueStatuses.Closed);
            }

            if (status == IssueStatuses.ReOpened)
            {
                enabledStatuses.Add(IssueStatuses.ReOpened);
                enabledStatuses.Add(IssueStatuses.CodeReview);
                enabledStatuses.Add(IssueStatuses.Closed);
            }

            if (status == IssueStatuses.Closed)
            {
                enabledStatuses.Add(IssueStatuses.Closed);
                enabledStatuses.Add(IssueStatuses.ReOpened);
            }


            return GetSelectListItems(enabledStatuses);
        }


        private static IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<IssueStatuses> elements)
        {
            var selectList = new List<SelectListItem>();

            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.ToString(),
                    Text = element.ToString()
                });
            }

            return selectList;
        }

    }
}