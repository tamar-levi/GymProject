using DAL.DTO;
using MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IGroup
    {
        public bool addGroup(GroupDto groupDto);
        public void removeGroup(int id);
        public (string status, GroupDto afterMapper) getGroupById(int id);

        public List<GroupDto> getAllGroups();
        public void addUserToGroup(int userId,int groupId);
        public void removeUserFromGroup(User user,int id);

        public void updateGroup(GroupDto groupDto);


    }
}
