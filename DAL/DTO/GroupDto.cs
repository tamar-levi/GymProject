using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS.Models;

namespace DAL.DTO
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int idGuide { get; set; }
        public typeGroup typeGroup { get; set; }
        public virtual ICollection<int> idUsers { get; set; }

        public string beginningDate { get; set; }
        public string endDate { get; set; }
        public int idFitnessMachines { get; set; }
    }
}
