using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EnduranceGoals.Models.ViewModels
{
    public class GoalViewModelValidationRules
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Range(typeof(DateTime), "1/1/2010", "1/12/2050", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime Date { get; set; }

        [Required]
        public string SportId { get; set; }

        [Required]
        public string VenueId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Value for {0} must contain less than {1} characters")]
        public string Web { get; set; }
    }
}