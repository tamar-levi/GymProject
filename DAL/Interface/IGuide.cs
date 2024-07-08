using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IGuide
    {

        public void addGuide(GuidDto guidDto);
        public void removeGguide(string id);
        public List<GuidDto> getAllGuides();
        public List<GuidDto> getGuidesByName(string name);


    }
}
