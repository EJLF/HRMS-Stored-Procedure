﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS_Stored_Procedure.Models
{
    public class DepartmentPosition
    {
        [Key]
        public int No { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
        [DisplayName("Position")]
        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        public Position? Position { get; set; }
    }
}
