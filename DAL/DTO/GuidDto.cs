using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace DAL.DTO
{
    public class GuidDto
    {
        public int Id { get; set; }

        public string name { get; set; }
        public string mail { get; set; }

        public string bankDetails { get; set; }
        public virtual ICollection<int> idGroups { get; set; }
    }
}
