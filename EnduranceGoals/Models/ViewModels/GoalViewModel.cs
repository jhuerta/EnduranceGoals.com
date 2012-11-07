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

        public string Venue { get; set; }
        public SelectList Venues { get; set; }

        public string Sport { get; set; }
        public SelectList Sports { get; set; }
    }
}