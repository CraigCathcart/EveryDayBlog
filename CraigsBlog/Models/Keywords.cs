﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CraigsBlog.Models
{
    public class Keywords
    {
        [Key]
        public int Id { get; set; }

        public string Keyword { get; set; }
    }
}