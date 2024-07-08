using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ISchedules
    {
        public void addSchedules(ScheduleDto scheduleDto);
        public void removeSchedules(int id);
         public List<ScheduleDto> getAllSchedules();
        public List<ScheduleDto> getSchedules(DateTime date);    
             

        
    }
        
}