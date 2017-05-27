using BugTracker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class EnabledStatuses
    {
        public static List<IssueStatuses> getEnabledIssueStatuses(IssueStatuses status)
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
          
            return enabledStatuses;
        }
    }
}