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
        public static bool CreateEntry(AttendanceRecordsDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AttendanceRecordsDTO, AttendanceRecord>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<AttendanceRecord>(obj);
            return EmployeeDAF.AttendanceData().CreateEntry(data);
        }
    }
}
