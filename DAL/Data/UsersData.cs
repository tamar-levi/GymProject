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
    public class UsersData : IUser
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        //אתחול ההזרקה
        public UsersData(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool createUser(UserDto user)
        {
            var myUser = _mapper.Map<User>(user);
            _context.Users.Add(myUser);
            var isOk = _context.SaveChanges() >= 0;

            return isOk;
        }

        public void deleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new NotImplementedException();
                //return ("Not Found", $"Fitness machine with ID {id} not found.");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public List<UserDto> getAllUsers()
        {
            var myUser = _context.Users.ToList();
            var myUserDto = _mapper.Map<List<UserDto>>(myUser);
            return myUserDto;
        }

        public (string status, UserDto afterMapper) getById(int id)
        {
            var idFind = _context.Users.FirstOrDefault(b =>b.Id==id);
            var afterMapper = _mapper.Map<UserDto>(idFind);
            if (afterMapper == null)
            {
                return ("Not Found", null);
            }
            return ("Found", afterMapper);
        }
    }
}
