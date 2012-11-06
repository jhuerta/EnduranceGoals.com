using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EnduranceGoals.Models.ViewModels
{
    public class GoalViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string SportName { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Web { get; set; }
        public DateTime CreatedOn { get; set; }
        public string VenueId { get; set; }
        public SelectList Venues { get; set; }
    }
}