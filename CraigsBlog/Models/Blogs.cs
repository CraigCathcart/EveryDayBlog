using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CraigsBlog.Models
{
    public class Blogs
    {
        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; }
       
        public string Content { get; set; }

        public string Keywords { get; set; }
        
        public bool IsPublic { get; set; }

        public virtual Users Users { get; set; }
    }
}