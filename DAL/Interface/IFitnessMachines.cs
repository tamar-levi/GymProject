using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    internal interface IFitnessMachines
    {
        public void addFitnessMachines(FitnesMmachinesDto fitnesMmachinesDto);
        public void removeFitnessMachines(FitnesMmachinesDto fitnesMmachinesDto);
        public void updateFitnessMachines(FitnesMmachinesDto fitnesMmachinesDto);
        public List<FitnesMmachinesDto> getAllFitnesMmachines();
        public FitnesMmachinesDto getFitnesMmachinesByArea(string area);


    }
}
