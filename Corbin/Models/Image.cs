using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Corbin.Models
{
    public class Image
    {
        public int Id { get; set; }
        public bool IsMainImage { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        public string URL { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}