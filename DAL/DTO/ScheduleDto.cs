using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    internal class ScheduleDto
    {
        public int id { get; set; }
        //prymari key
        public int idGroup { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int BeginningTime { get; set; }
        public int EndTime { get; set; }
        public int idFitnessMachines { get; set; }
    }
}
