using AutoMapper;
using DAL.DTO;
using DAL.Interface;
using MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class GroupData : IGroup
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GroupData(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool addGroup(GroupDto groupDto)
        {
            var myGroup = _mapper.Map<Group>(groupDto);
            _context.Groups.Add(myGroup);
            var isOk = _context.SaveChanges() >= 0;
            return isOk;
        }

        public void addUserToGroup(int userId,int groupId)
        {
            var group = _context.Groups.Find(groupId);
            if (group == null)
            {
                throw new NotImplementedException();
            }
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                throw new NotImplementedException();
            }
            if(group.users==null)
                group.users = new List<User>();

            group.users.Add(user);

            _context.SaveChanges();
        }
        public List<GroupDto> getAllGroups()
        {
            var myGroups = _context.Groups.ToList();
            var myGroupDto = _mapper.Map<List<GroupDto>>(myGroups);
            return myGroupDto;
        }

        public (string status, GroupDto afterMapper) getGroupById(int id)
        {
            var groupFind = _context.Groups.FirstOrDefault(b => b.Id == id);
            var afterMapper = _mapper.Map<GroupDto>(groupFind);
            if (afterMapper == null)
            {
                return ("Not Found", null);
            }
            return ("Found", afterMapper);
        }

        public void removeGroup(int id)
        {
            var group = _context.Groups.Find(id);
            if (group == null)
            {
                throw new NotImplementedException();
            }

            _context.Groups.Remove(group);
            _context.SaveChanges();
        }

        public void removeUserFromGroup(User user, int groupId)
        {
            var group = _context.Groups.Find(groupId);
            if (group == null)
            {
                throw new NotImplementedException();
            }
            var userId = group.users.FirstOrDefault(user);
            if (userId == null)
            {
                throw new NotImplementedException();
            }

           group.users.Remove(userId);
            _context.Groups.Update(group);
            _context.SaveChanges();
        }

      

        public void updateGroup(GroupDto groupDto)
        {
            var group = _context.Groups.Find(groupDto.Id);
            if (group == null)
            {
                throw new NotImplementedException();
            }

            group.name = groupDto.name;
            group.typeGroup= groupDto.typeGroup;
            group.endDate= groupDto.endDate;
            group.beginningDate= groupDto.beginningDate;
            group.name= groupDto.name;
            _context.Groups.Update(group);
            _context.SaveChanges();
        }

    }
}
