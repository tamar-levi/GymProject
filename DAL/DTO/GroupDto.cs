﻿using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.DTO
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int GuideId { get; set; }
        public typeGroup typeGroup { get; set; }
        public virtual ICollection<int> idUsers { get; set; }
        public string beginningDate { get; set; }
        public string endDate { get; set; }
        public int idFitnessMachines { get; set; }
        public int managerId { get; set; }

    }
}
