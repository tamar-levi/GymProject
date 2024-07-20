using DAL.Data;
using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUser
    {
        public bool createUser(UserDto user);
        public void deleteUser(int id);
        public List<UserDto> getAllUsers();
        public (string status, UserDto afterMapper) getByMail(string mail);


           



    }
}
