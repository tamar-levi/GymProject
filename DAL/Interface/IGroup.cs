using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    internal interface IGroup
    {
        public void addGroup(GroupDto groupDto);
        public void removeGroup(int id);
        public GroupDto getGroupById(int id);

        public List<GroupDto> getAllGroups();
        public List<GroupDto> getGroupsByArea(string address);
        public void addUserToGroup(UserDto userDto);
        public void removeUserFromGroup(int id);

        public void updateGroup(GroupDto groupDto);


    }
}
