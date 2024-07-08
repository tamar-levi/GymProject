using DAL.DTO;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class UsersData : IUser
    {
        public void creatUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public void deleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> getAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDto getById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
