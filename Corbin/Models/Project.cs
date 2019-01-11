using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Corbin.Models
{
    public class Project
    {
        public int Id { get; set; }
        [StringLength(200, ErrorMessage = "Title length not valid")]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime LastUpdated { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser User { get; set; }

        public Project()
        {

        }

        public Project(string Title, string Description)
        {
            this.Title = Title;
            this.Description = Description;
            EntryDate = DateTime.UtcNow;
            LastUpdated = DateTime.UtcNow;
        }
    }
}