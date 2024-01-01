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
    public class AssignTaskHandelService
    {
        public static bool CreateTask(AssignedTaskDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AssignedTaskDTO, AssignedTask>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<AssignedTask>(obj);
            return ManagerDAF.ATData().create(mapped);
        }

        public static List<AssignedTaskDTO> GetAll()
        {
            var data = ManagerDAF.ATData().GetAll();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AssignedTask, AssignedTaskDTO>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<AssignedTaskDTO>>(data);
            return mapped;
        }

        public static AssignedTaskDTO Get(int id)
        {
            var data = ManagerDAF.ATData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AssignedTask, AssignedTaskDTO>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<AssignedTaskDTO>(data);
            return mapped;
        }

        public static bool delete(int id)
        {
            return ManagerDAF.ATData().Delete(id);
        }

        public static bool update(int id, AssignedTaskDTO obj)
        {
            var exdata = ManagerDAF.ATData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AssignedTaskDTO, AssignedTask>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<AssignedTask>(obj);
            exdata.TaskName = obj.TaskName;
            exdata.Description = obj.Description;
            exdata.DueDate = obj.DueDate;
            exdata.AssignedToID = obj.AssignedToID;
            exdata.AssignedByID = obj.AssignedByID;
            exdata.Priority = obj.Priority;
            return ManagerDAF.ATData().Update(exdata);
        }
    }
}
