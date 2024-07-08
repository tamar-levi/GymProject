﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Models
{
    public class Guide
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string mail { get; set; }

        public string bankDetails { get; set; }
        public virtual ICollection<Group> groups { get; set; }
    }
}
