using DAL.DTO;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class GroupData : IGroup
    {
        public void addGroup(GroupDto groupDto)
        {
            throw new NotImplementedException();
        }

        public void addUserToGroup(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public List<GroupDto> getAllGroups()
        {
            throw new NotImplementedException();
        }

        public GroupDto getGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public List<GroupDto> getGroupsByArea(string address)
        {
            throw new NotImplementedException();
        }

        public void removeGroup(int id)
        {
            throw new NotImplementedException();
        }

        public void removeUserFromGroup(int id)
        {
            throw new NotImplementedException();
        }

        public void updateGroup(GroupDto groupDto)
        {
            throw new NotImplementedException();
        }
    }
}
