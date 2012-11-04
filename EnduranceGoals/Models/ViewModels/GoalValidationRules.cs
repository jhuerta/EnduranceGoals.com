using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EnduranceGoals.Models.ViewModels
{
    public class GoalValidationRules
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Range(typeof(DateTime), "1/1/2010", "1/12/2050", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public virtual DateTime Date { get; set; }

        [Required]
        public virtual Sport Sport { get; set; }

        [Required]
        public virtual User UserCreator { get; set; }
   
        [Required]
        public virtual Venue Venue { get; set; }

        [Required]
        [StringLength(75)]
        public virtual string Name { get; set; }

        [Required]
        public virtual string Description { get; set; }

        [Required]
        [StringLength(50,ErrorMessage = "Value for {0} must contain less than {1} characters")]
        public virtual string Web { get; set; }
    }
}