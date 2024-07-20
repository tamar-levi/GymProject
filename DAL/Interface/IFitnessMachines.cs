using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IFitnessMachines
    {
        public bool addFitnessMachines(FitnesMachinesDto fitnessMachinesDto);
        public void removeFitnessMachines(int id);
        public bool updateFitnessMachines(FitnesMachinesDto fitnessMmachinesDto);
        public List<FitnesMachinesDto> getAllFitnessMachines();
        public(string status, FitnesMachinesDto afterMapper) getFitnessMachinesByArea(string address);


    }
}
