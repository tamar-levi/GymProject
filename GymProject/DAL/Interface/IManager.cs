﻿using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IManager
    {
        public List<ManagerDto> getAllManager();
        public bool addManager(ManagerDto managerDto);
    }
}
