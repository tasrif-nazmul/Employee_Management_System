using AutoMapper;
using BusinessLogicLayer.DTOs.EmployeeDTOs;
using DataAccessLayer.EF;
using DataAccessLayer.Repos.EmployeeRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.EmployeeServices
{
    public class LeaveRequestService
    {
        public static bool Create(LeaveRequestDTO lr)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeaveRequestDTO, LeaveRequest>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<LeaveRequest>(lr);
            return LeaveRequestRepo.Create(data);
        }
    }
}
