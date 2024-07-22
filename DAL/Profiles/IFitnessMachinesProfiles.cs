using AutoMapper;
using DAL.DTO;
using DAL.Interface;
using Microsoft.Win32.SafeHandles;
using MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Profiles
{
    public class IFitnessMachinesProfiles: Profile
    {
        public IFitnessMachinesProfiles()
        {
            CreateMap<FitnessMachines, FitnesMachinesDto>();
            CreateMap<FitnesMachinesDto, FitnessMachines>();
            CreateMap<Group, GroupDto>();
            CreateMap<GroupDto, Group>();   
            CreateMap<Guide, GuidDto>();
            CreateMap<GuidDto, Guide>();
            CreateMap<ScheduleDto, ScheduleDto>();
            CreateMap<ScheduleDto, Schedules>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<ManagerDto, Manager>();
            CreateMap<UserDto, User>();
            CreateMap<Manager, ManagerDto>();    


        }
    }
}

