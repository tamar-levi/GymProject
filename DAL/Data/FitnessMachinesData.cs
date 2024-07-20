using DAL.DTO;
using DAL.Interface;
using MODELS.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.PortableExecutable;

namespace DAL.Data
{

    public class FitnessMachinesData : IFitnessMachines
    {

        private readonly Context _context;
        private readonly IMapper _mapper;
        //אתחול ההזרקה
        public FitnessMachinesData(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //הוספת חדר כושר
        public bool addFitnessMachines(FitnesMachinesDto fitnessMachines)
        {
            var myFitnessMachines = _mapper.Map<FitnessMachines>(fitnessMachines);
            _context.FitnessMachines.Add(myFitnessMachines);
            var isOk = _context.SaveChanges() >= 0;

            return isOk;
        }

        //מחזירה את כל רשימת המכונות כושר
        public List<FitnesMachinesDto> getAllFitnessMachines()
        {
            var myFitnessMachines = _context.FitnessMachines.ToList();
            var myFitnessMachineDto = _mapper.Map<List<FitnesMachinesDto>>(myFitnessMachines);
            return myFitnessMachineDto;
        }

        //מחזירה את רשימת המכונות לפי אזור
        public (string status, FitnesMachinesDto afterMapper) getFitnessMachinesByArea(string address)
        {

            var areaFind = _context.FitnessMachines.FirstOrDefault(b => b.address == address);
            var afterMapper = _mapper.Map<FitnesMachinesDto>(areaFind);
            if (afterMapper == null)
            {
                return ("Not Found", null);
            }
            return ("Found", afterMapper);
        }

        //מוחק מכון כושר לפי id
        public void removeFitnessMachines(int id)
        {
            var machine = _context.FitnessMachines.Find(id);
            if (machine == null)
            {
                throw new NotImplementedException();
                //return ("Not Found", $"Fitness machine with ID {id} not found.");
            }

            _context.FitnessMachines.Remove(machine);
            _context.SaveChanges();
            // return ("Success", $"Fitness machine with ID {id} was deleted successfully.");
        }

        //עידכון מכון כושר
        public void updateFitnessMachines(FitnesMachinesDto fitnessMachinesDto)
        {
            var machine = _context.FitnessMachines.Find(fitnessMachinesDto.Id);
            if (machine == null)
            {
                throw new NotImplementedException();
                //return ("Not Found", $"Fitness machine with ID {id} not found.");
            }

            machine.name = fitnessMachinesDto.name;
            machine.address = fitnessMachinesDto.address;


            _context.FitnessMachines.Update(machine);
            _context.SaveChanges();
        }
    }
}






       

       