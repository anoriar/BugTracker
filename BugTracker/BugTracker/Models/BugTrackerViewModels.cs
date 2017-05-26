using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BugTracker.Models
{
    public class IssueCreateModel
    {

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "User")]
        public List<string> User { get; set; }

        [Required]
        [Display(Name = "Price")]
        public string Price { get; set; }

    }

    public class IssueViewModel
    {

        public int? Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }


        [Display(Name = "Users")]
        public List<string> Users { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }


        [Display(Name = "Price")]
        public string Price { get; set; }
    }

    public class ProjectCreateModel
    {

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public string Customer { get; set; }


        [Required]
        [Display(Name = "Manager")]
        public string Manager { get; set; }

    }

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
