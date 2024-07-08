using DAL.DTO;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class GuidData : IGuide
    {
        public void addGuide(GuidDto guidDto)
        {
            throw new NotImplementedException();
        }

        public List<GuidDto> getAllGuides()
        {
            throw new NotImplementedException();
        }

        public List<GuidDto> getGuidesByName(string name)
        {
            throw new NotImplementedException();
        }

        public void removeGguide(string id)
        {
            throw new NotImplementedException();
        }
    }
}
