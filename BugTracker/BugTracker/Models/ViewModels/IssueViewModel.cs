using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.Models.ViewModels
{
    public class IssueViewModel
    {

  
        public int? Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

      
        [Display(Name = "Description")]
        public string Description { get; set; }

       
        [Display(Name = "User")]
        public string User { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }


        [Display(Name = "Price")]
        public string Price { get; set; }
    }
}