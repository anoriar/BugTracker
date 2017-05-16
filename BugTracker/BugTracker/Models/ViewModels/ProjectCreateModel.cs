using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BugTracker.Models.ViewModels
{
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
}