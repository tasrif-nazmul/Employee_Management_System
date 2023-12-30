using AutoMapper;
using BusinessLogicLayer.DTOs.EmployeeDTOs;
using DataAccessLayer;
using DataAccessLayer.DAF;
using DataAccessLayer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.EmployeeServices
{
    public class AssignedTaskService
    {
        public static List<AssignedTaskDTO> GetAll()
        {
            var data = EmployeeDAF.AssignedTaskData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AssignedTask, AssignedTaskDTO>();
            });

            var mapper = new Mapper(config);
            return mapper.Map<List<AssignedTaskDTO>>(data);
        }

        public static AssignedTaskDTO Get(int id)
        {
            var data = EmployeeDAF.AssignedTaskData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AssignedTask, AssignedTaskDTO>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<AssignedTaskDTO>(data);
            return mapped;
        }

        public static bool Received(int id, AssignedTaskDTO obj)
        {
            var exdata = EmployeeDAF.AssignedTaskData().Get(id);
            exdata.Status = "In Progress";
            return EmployeeDAF.AssignedTaskData().TaskHandle(exdata);
        } 
        public static bool Submit(int id, AssignedTaskDTO obj)
        {
            var exdata = EmployeeDAF.AssignedTaskData().Get(id);
            exdata.Status = "Completed";
            return EmployeeDAF.AssignedTaskData().TaskHandle(exdata);
        }
    }
}
