using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Corbin.Models
{
    public class test2
    {
        public int Id { get; set; }
        public string Test2 { get; set; }

        public int TestId { get; set; }
        [ForeignKey("TestId")]
        public test Test { get; set; }
    }
}