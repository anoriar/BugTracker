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
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Стоимость")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Разработчик")]
        public string DeveloperId { get; set; }

        public IEnumerable<SelectListItem> Developers { get; set; } 

    }

    public class IssueDetailModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Title { get; set; }


        [Display(Name = "Описание")]
        public string Description { get; set; }


        [Display(Name = "Разработчик")]
        public string Developer { get; set; }

        [Display(Name = "Статус")]
        public string Status { get; set; }


        [Display(Name = "Стоимость")]
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
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Стоимость")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Разработчик")]
        public string DeveloperId { get; set; }

        public IEnumerable<SelectListItem> Developers { get; set; }

    }

    public class ProjectCreateModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Заказчик")]
        public string Customer { get; set; }

        [Required]
        [Display(Name = "Менеджер")]
        public string ManagerId { get; set; }

        public IEnumerable<SelectListItem> Managers { get; set; } 
    }

    public class ProjectDetailModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Заказчик")]
        public string Customer { get; set; }

        [Display(Name = "Менеджер")]
        public string ManagerName { get; set; }

        [Display(Name = "Задачи")]
        public List<Issue> Issues { get; set; }
    }
}
