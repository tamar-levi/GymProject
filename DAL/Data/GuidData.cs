using AutoMapper;
using DAL.DTO;
using DAL.Interface;
using MODELS.Models;


namespace DAL.Data
{
    public class GuidData : IGuide
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GuidData(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool addGuide(GuidDto guidDto)
        {
            var myGuide = _mapper.Map<Guide>(guidDto);
            _context.Guides.Add(myGuide);
            Console.WriteLine(  "i am here");
            var isOk = _context.SaveChanges() >= 0;
            return isOk;
        }

        public List<GuidDto> getAllGuides()
        {
            var myGuides = _context.Guides.ToList();
            var myGuideDto = _mapper.Map<List<GuidDto>>(myGuides);
            return myGuideDto;
        }

        public (string status, GuidDto afterMapper) getGuidesByName(string name)
        {
            var FindName = _context.Guides.FirstOrDefault(b => b.name==name);
            var afterMapper = _mapper.Map<GuidDto>(FindName);
            if (afterMapper == null)
            {
                return ("Not Found", null);
            }
            return ("Found", afterMapper);
        }

        public void removeGuide(int id)
        {
            var guide = _context.Guides.Find(id);
            if (guide == null)
            {
                throw new NotImplementedException();
            }

            _context.Guides.Remove(guide);
            _context.SaveChanges();
        }

        public bool updateGuide(GuidDto guide)
        {

            var guideFind = _context.Guides.Find(guide.Id);
            if (guideFind == null)
            {
                throw new NotImplementedException();
                
            }

            guideFind.name = guide.name;
            guideFind.mail = guide.mail;
            guideFind.bankDetails = guide.bankDetails;
          
            _context.Guides.Update(guideFind);
            return _context.SaveChanges() > 0;

        }
    }
}
