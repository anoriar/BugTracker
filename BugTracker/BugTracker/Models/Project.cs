using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Customer { get; set; }


        public string Manager { get; set; }

        public virtual List<Issue> Issues { get; set; }

    }
}