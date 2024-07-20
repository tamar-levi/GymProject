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

        public void addUserToGroup(User user,int groupId)
        {
            var group = _context.Groups.Find(groupId);
            if (group == null)
            {
                throw new NotImplementedException();
                //return ("Not Found", $"Fitness machine with ID {id} not found.");
            }
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
            var group = _context.groups.Find(id);
            if (group == null)
            {
                throw new NotImplementedException();
                //return ("Not Found", $"Fitness machine with ID {id} not found.");
            }

            _context.groups.Remove(group);
            _context.SaveChanges();
        }

        public void removeUserFromGroup(User user, int groupId)
        {
            var group = _context.groups.Find(groupId);
            if (group == null)
            {
                throw new NotImplementedException();
                //return ("Not Found", $"Fitness machine with ID {id} not found.");
            }
            var userId = group.users.FirstOrDefault(user);
            if (userId == null)
            {
                throw new NotImplementedException();
                //return ("Not Found", $"Fitness machine with ID {id} not found.");
            }

           group.users.Remove(userId);
            _context.groups.Update(group);
            _context.SaveChanges();
        }

      

        public void updateGroup(GroupDto groupDto)
        {
            var group = _context.Groups.Find(groupDto.Id);
            if (group == null)
            {
                throw new NotImplementedException();
                //return ("Not Found", $"Fitness machine with ID {id} not found.");
            }

            group.name = groupDto.name;
            group.typeGroup= groupDto.typeGroup;
            group.endDate= groupDto.endDate;
            group.beginningDate= groupDto.beginningDate;
            group.name= groupDto.name;
            //group.guidName.Id = groupDto.Id;
            _context.Groups.Update(group);
            _context.SaveChanges();
        }

    }
}
