using AutoMapper;
using DAL.DTO;
using DAL.Interface;
using MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class SchedulesData : ISchedules
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        //אתחול ההזרקה
        public SchedulesData(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool addSchedules(ScheduleDto scheduleDto)
        {
            var mySchedules = _mapper.Map<Schedules>(scheduleDto);
            _context.Schedules.Add(mySchedules);
            var isOk = _context.SaveChanges() >= 0;
            return isOk;
        }

        public List<ScheduleDto> getAllSchedules()
        {
            var mySchedules = _context.Schedules.ToList();
            var mySchedulesDto = _mapper.Map<List<ScheduleDto>>(mySchedules);
            return mySchedulesDto;
        }

        public (string status, ScheduleDto afterMapper) getSchedulesByDate(DateTime date)
        {
            var dateFind = _context.Schedules.FirstOrDefault(b =>b.year==date.Year&&b.month==date.Month&&b.day==date.Day);
            var afterMapper = _mapper.Map<ScheduleDto>(dateFind);
            if (afterMapper == null)
            {
                return ("Not Found", null);
            }
            return ("Found", afterMapper);
        }

        public void removeSchedules(int id)
        {
            var schedules = _context.Schedules.Find(id);
            if (schedules == null)
            {
                throw new NotImplementedException();
                //return ("Not Found", $"Fitness machine with ID {id} not found.");
            }

            _context.Schedules.Remove(schedules);
            _context.SaveChanges();
        }
    }
}
