using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Corbin.Models
{
    public class ProjectImage
    {
        public int Id { get; set; }
        public bool IsMainImage { get; set; }
        public string Description { get; set; }
        public byte[] imageStream { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public MyProject Project { get; set; }
    }
}
