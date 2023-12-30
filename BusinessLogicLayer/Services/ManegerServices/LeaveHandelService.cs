using AutoMapper;
using BusinessLogicLayer.DTOs.EmployeeDTOs;
using DataAccessLayer.DAF;
using DataAccessLayer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.ManegerServices
{
    public class LeaveHandelService
    {
        public static List<LeaveRequestDTO> GetAll()
        {
            var data = ManagerDAF.LRData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeaveRequest, LeaveRequestDTO>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<LeaveRequestDTO>>(data);
            return mapped;
        }
    }
}
