using AutoMapper;
using BusinessLogicLayer.DTOs.EmployeeDTOs;
using DataAccessLayer.EF;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DAF;

namespace BusinessLogicLayer.Services.EmployeeServices
{
    public class AttendanceService
    {
        public static bool CreateEntry(int id)
        {
            return EmployeeDAF.AttendanceData().CreateEntry(id);
        }
        public static bool CreateExit(int id)
        {
            return EmployeeDAF.AttendanceData().CreateExit(id);
        }
    }
}
