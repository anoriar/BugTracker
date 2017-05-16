using BugTracker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class EnabledStatuses
    {
        public static List<string> getEnabledIssueStatuses(string status)
        {
       
            List<string> enabledStatuses = new List<string>();
            if (status == "Open")
            {
                enabledStatuses.Add(IssueStatuses.Open.ToString());
                enabledStatuses.Add(IssueStatuses.CodeReview.ToString());
                enabledStatuses.Add(IssueStatuses.Closed.ToString());
            }

            if (status == "CodeReview")
            {
                enabledStatuses.Add(IssueStatuses.CodeReview.ToString());
                enabledStatuses.Add(IssueStatuses.ReOpened.ToString());
                enabledStatuses.Add(IssueStatuses.Closed.ToString());
            }

            if (status == "ReOpened")
            {
                enabledStatuses.Add(IssueStatuses.ReOpened.ToString());
                enabledStatuses.Add(IssueStatuses.CodeReview.ToString());
                enabledStatuses.Add(IssueStatuses.Closed.ToString());
            }

            if (status == "Closed")
            {
                enabledStatuses.Add(IssueStatuses.Closed.ToString());
                enabledStatuses.Add(IssueStatuses.ReOpened.ToString());
               
            }
          
            return enabledStatuses;
        }
    }
}