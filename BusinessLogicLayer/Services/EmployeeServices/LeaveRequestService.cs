using AutoMapper;
using BusinessLogicLayer.DTOs.EmployeeDTOs;
using DataAccessLayer;
using DataAccessLayer.DAF;
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
            return EmployeeDAF.LeaveReqData().Create(data);
        }

        public static List<LeaveRequestDTO> GetAll()
        {
            var data = EmployeeDAF.LeaveReqData().GetAll();
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
            var data = EmployeeDAF.LeaveReqData().Get(id);
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
            return EmployeeDAF.LeaveReqData().Delete(id);
        }

        public static bool update(int id, LeaveRequestDTO obj)
        {
            var exdata = EmployeeDAF.LeaveReqData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeaveRequestDTO, LeaveRequest>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<LeaveRequest>(obj);
            exdata.EmployeeID = obj.EmployeeID;
            exdata.LeaveType = obj.LeaveType;
            exdata.LeaveStartDate = obj.LeaveStartDate;
            exdata.LeaveEndDate = obj.LeaveEndDate;
            return EmployeeDAF.LeaveReqData().Update(exdata);
        }
    }
}
