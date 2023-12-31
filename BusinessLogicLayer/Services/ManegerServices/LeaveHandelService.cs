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

        public static LeaveRequestDTO Get(int id)
        {
            var data = ManagerDAF.LRData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LeaveRequest, LeaveRequestDTO>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<LeaveRequestDTO>(data);
            return mapped;
        }

        public static bool Accept(int id, LeaveRequestDTO obj)
        {
            var data = ManagerDAF.LRData().Get(id);
            data.Status = "Accept";
            return ManagerDAF.LRData().LeaveReqHandle(data);
        }
        public static bool Reject(int id, LeaveRequestDTO obj)
        {
            var data = ManagerDAF.LRData().Get(id);
            data.Status = "Reject";
            return ManagerDAF.LRData().LeaveReqHandle(data);
        }
    }
}
