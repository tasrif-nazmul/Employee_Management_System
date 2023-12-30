using AutoMapper;
using BusinessLogicLayer.DTOs.EmployeeDTOs;
using DataAccessLayer;
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
            return DataAccessFactory.LeaveReqData().Create(data);
        }

        public static List<LeaveRequestDTO> GetAll()
        {
            var data = DataAccessFactory.LeaveReqData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeaveRequest, LeaveRequestDTO>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<LeaveRequestDTO>>(data);
            return mapped;
        }

        public static LeaveRequestDTO Get(int id)
        {
            var data = DataAccessFactory.LeaveReqData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeaveRequest, LeaveRequestDTO>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<LeaveRequestDTO>(data);
            return mapped;
        }

        public static bool delete(int id)
        {
            return DataAccessFactory.LeaveReqData().Delete(id);
        }
    }
}
