using AutoMapper;
using BusinessLogicLayer.DTOs.EmployeeDTOs;
using BusinessLogicLayer.Services.Admin;
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

        //EmployeeTask
        //public static List<AssignedTaskDTO> GetEmployeeTask(int id)
        //{
        //    var data = EmployeeDAF.AssignedTaskData().GetAll();
        //    var dataByEmp = data.Where(t => t.AssignedToID.Equals(id)).ToList();
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<AssignedTask, AssignedTaskDTO>();
        //    });

        //    var mapper = new Mapper(config);
        //    var mapped = mapper.Map<List<AssignedTaskDTO>>(dataByEmp);
        //    return mapped;
        //}

        //public static EmployeeWithTaskDTO GetEmployeeDetailsWithTasks(int employeeId)
        //{
        //    var employeeData = AdminDAF.EmployeeData().Get(employeeId); // Replace with actual method to get employee details
        //    var assignedTaskData = EmployeeDAF.AssignedTaskData().GetAll().Where(t => t.AssignedToID.Equals(employeeId)).ToList();

        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<Employee, EmployeeWithTaskDTO>()
        //            .ForMember(dest => dest.EmployeeID, opt => opt.MapFrom(src => src.EmployeeID))
        //            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.EmployeeName))
        //            .ForMember(dest => dest.AssignedTasks, opt => opt.MapFrom(src => src.AssignedTasks));

        //        cfg.CreateMap<AssignedTask, AssignedTaskDTO>();
        //    });

        //    var mapper = new Mapper(config);

        //    var employeeDetailsWithTasks = mapper.Map<EmployeeWithTaskDTO>(employeeData);
        //    employeeDetailsWithTasks.AssignedTasks = mapper.Map<List<AssignedTaskDTO>>(assignedTaskData);

        //    return employeeDetailsWithTasks;
        //}

        public static EmployeeWithTaskDTO GetEmployeeWithTasks(int employeeId)
        {
            var employeeData = AdminDAF.EmployeeData().Get(employeeId);
            var assignedTaskData = EmployeeDAF.AssignedTaskData().GetAll().Where(t => t.AssignedToID.Equals(employeeId)).ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeWithTaskDTO>();

                cfg.CreateMap<AssignedTask, AssignedTaskDTO>();
            });

            var mapper = new Mapper(config);

            var employeeDetailsWithTasks = mapper.Map<EmployeeWithTaskDTO>(employeeData);
            employeeDetailsWithTasks.AssignedTasks = mapper.Map<List<AssignedTaskDTO>>(assignedTaskData);

            return employeeDetailsWithTasks;
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
