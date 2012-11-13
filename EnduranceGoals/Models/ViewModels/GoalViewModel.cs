using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EnduranceGoals.Models.ViewModels
{
    public partial class GoalViewModel
    {

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Web { get; set; }

        public string VenueId { get; set; }
        public ICollection<SelectListItem> Venues { get; set; }

        public string SportId { get; set; }
        public ICollection<SelectListItem> Sports { get; set; }
    }
}