using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Corbin.Models
{
    public class Video
    {
        public int Id { get; set; }
        public bool IsMainVideo { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }

    }
}