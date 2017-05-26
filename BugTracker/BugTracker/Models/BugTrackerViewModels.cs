using BugTracker.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BugTracker.Models
{
    public class IssueCreateModel
    {
        [Key]
        public int Id { get; set; }

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

        public int ProjectId { get; set; }

    }

    public class IssueViewModel
    {
         [Key]
        public int Id { get; set; }

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

        public int ProjectId { get; set; }

        List<IssueStatuses> EnabledStatuses { get; set; }

        public IssueViewModel()
        {
            EnabledStatuses = new List<IssueStatuses>();
        }
    }

    public class ProjectCreateModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Customer")]
        public string Customer { get; set; }

        public int Manager { get; set; }

    }

    public class ProjectViewModel
    {
         [Key]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }


        [Display(Name = "Customer")]
        public string Customer { get; set; }

        [Display(Name = "Manager")]
        public string Manager { get; set; }

        public List<Issue> Issues { get; set; }

        public ProjectViewModel()
        {
            Issues = new List<Issue>();
        }

    }
}
