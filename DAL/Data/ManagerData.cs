using AutoMapper;
using DAL.DTO;
using DAL.Interface;
using MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class ManagerData : IManager
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        //אתחול ההזרקה
        public ManagerData(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool addManager(ManagerDto managerDto)
        {
            var MyManager = _mapper.Map<Manager>(managerDto);
            _context.Managers.Add(MyManager);
            var isOk = _context.SaveChanges() >= 0;

            return isOk;
        }

        public List<ManagerDto> getAllManager()
        {
            var MyManager = _context.Managers.ToList();
            var MyManagerDto = _mapper.Map<List<ManagerDto>>(MyManager);
            return MyManagerDto;
        }
    }
}
