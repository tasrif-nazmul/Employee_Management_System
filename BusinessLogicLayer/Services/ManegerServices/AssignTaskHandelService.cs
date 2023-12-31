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
    }
}
