using DAL.DTO;
using DAL.Interface;
using MODELS.Models;
using AutoMapper;


namespace DAL.Data
{

    public class FitnessMachinesData : IFitnessMachines
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        //The injection initialization
        public FitnessMachinesData(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Adding a gym
        public bool addFitnessMachines(FitnesMachinesDto fitnessMachines)
        {
            var myFitnessMachines = _mapper.Map<FitnessMachines>(fitnessMachines);
            _context.FitnessMachines.Add(myFitnessMachines);
            var isOk = _context.SaveChanges() >= 0;
            return isOk;
        }

        //Returns the entire list of fitness machines
        public List<FitnesMachinesDto> getAllFitnessMachines()
        {
            var myFitnessMachines = _context.FitnessMachines.ToList();
            var myFitnessMachineDto = _mapper.Map<List<FitnesMachinesDto>>(myFitnessMachines);
            return myFitnessMachineDto;
        }

        //Returns the list of machines by region
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

        //Deletes a gym by id
        public void removeFitnessMachines(int id)
        {
            var machine = _context.FitnessMachines.Find(id);
            if (machine == null)
            {
                throw new NotImplementedException();
               
            }

            _context.FitnessMachines.Remove(machine);
            _context.SaveChanges();
            
        }

        //Gym update
        public bool updateFitnessMachines(FitnesMachinesDto fitnessMachinesDto)
        {
            var machine = _context.FitnessMachines.Find(fitnessMachinesDto.Id);
            if (machine == null)
            {
                throw new NotImplementedException();
                
            }

            machine.name = fitnessMachinesDto.name;
            machine.address = fitnessMachinesDto.address;


            _context.FitnessMachines.Update(machine);
            _context.SaveChanges();
        }
    }
}






       

       