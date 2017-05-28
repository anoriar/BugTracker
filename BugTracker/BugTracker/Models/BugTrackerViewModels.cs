using BugTracker.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Models
{
    public class IssueCreateModel
    {
        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Developer")]
        public string DeveloperId { get; set; }

        public IEnumerable<SelectListItem> Developers { get; set; } 

    }

    public class IssueDetailModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }


        [Display(Name = "Developer")]
        public string Developer { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }


        [Display(Name = "Price")]
        public decimal Price { get; set; }

        public int ProjectId { get; set; }

        public IEnumerable<SelectListItem> EnabledStatuses { get; set; } 

    }

    public class IssueEditModel
    {
        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Developer")]
        public string DeveloperId { get; set; }

        public IEnumerable<SelectListItem> Developers { get; set; }

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

        [Required]
        [Display(Name = "Manager")]
        public string ManagerId { get; set; }

        public IEnumerable<SelectListItem> Managers { get; set; } 
    }

    public class ProjectDetailModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Customer")]
        public string Customer { get; set; }

        [Display(Name = "ManagerName")]
        public string ManagerName { get; set; }

        [Display(Name = "Issues")]
        public List<Issue> Issues { get; set; }
    }
}
