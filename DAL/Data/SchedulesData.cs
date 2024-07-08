using DAL.DTO;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class SchedulesData : ISchedules
    {
        public void addSchedules(ScheduleDto schedulleDto)
        {
            throw new NotImplementedException();
        }

        public List<ScheduleDto> getAllSchedules()
        {
            throw new NotImplementedException();
        }

        public List<ScheduleDto> getSchedules(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void removeSchedules(int id)
        {
            throw new NotImplementedException();
        }
    }
}
