using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.Models.ViewModels
{
    public class ProjectViewModel
    {

        public int? Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

       
        [Display(Name = "Description")]
        public string Description { get; set; }

     
        [Display(Name = "Customer")]
        public string Customer { get; set; }

        [Display(Name = "Manager")]
        public string Manager { get; set; }

        public List<Issue> Issues { get; set; }


    }
}