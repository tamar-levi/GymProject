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
        public void creatUser(UserDto user);
        public void deleteUser(string id);
        public List<UserDto> getAllUsers();
        public UserDto getById(string id);


           



    }
}
