using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EnduranceGoals.Models.ViewModels
{
    public partial class GoalViewModel
    {
        public bool CanJoin { get; set; }
        public string Location { get; set; }
        public IDictionary<int, string> ListOrParticipants  { get; set; }
        public bool UserCanModifyEvent { get; set; }
        public bool UserLoggedIn { get; set; }

        public string SportName { get; set; }
        public bool CanBeDeleted { get; set; }

        public string UserCreatorUsername { get; set; }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Time)]  
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        public string Description { get; set; }
        public string Web { get; set; }

        public string VenueId { get; set; }
        public ICollection<SelectListItem> Venues { get; set; }

        public string SportId { get; set; }
        public ICollection<SelectListItem> Sports { get; set; }
    }
}