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

        public bool addGuide(GuidDto guideDto);
        public void removeGuide(int id);
        public List<GuidDto> getAllGuides();
        public (string status, GuidDto afterMapper) getGuidesByName(string name);
        public bool updateGuide(GuidDto guide);


    }
}
