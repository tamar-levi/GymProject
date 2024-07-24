using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.Models
{
    public class Schedules
    {
        //id רץ
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public int idGroup { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int BeginningTime { get; set; }
        public int EndTime { get; set; }
        public int idFitnessMachines { get; set; }



    }
}
