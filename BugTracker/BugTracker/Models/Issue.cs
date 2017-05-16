using BugTracker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class Issue
    {
        public int Id { get; set; }

        public int Number{ get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public IssueStatuses Status { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int? ProjectId { get; set; }
    
    }
}