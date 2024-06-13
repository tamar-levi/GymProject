using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Models
{
    public enum typeGroup { Gymnastics, postpartumGymnastics, aerobics, hipHop, pilates, floorGymnastics }
    internal class Group
    {
        //ID רץ
        public int idGroup { get; set; }
        public string name { get; set; }
        public Guide guidName { get; set; }
        public typeGroup typeGroup { get; set; }
        public virtual ICollection<User>users { get; set; }

        public string beginningDate { get; set; }
        public string endDate { get; set; }
        public int idFitnessMachines { get; set; }

    }
}
