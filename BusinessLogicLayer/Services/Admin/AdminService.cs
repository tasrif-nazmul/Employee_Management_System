using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.EF;
using DataAccessLayer.Repos.Admin;
using BusinessLogicLayer.DTOs.AdminDTOs;
using DataAccessLayer.DAF;

namespace BusinessLogicLayer.Services.Admin
{
    public class AdminService
    {
        public static List<AdminDTO> GetAll()
        {
            var data = AdminDAF.EmployeeData().GetAll();
           var config = new MapperConfiguration(cfg => {
               cfg.CreateMap<Employee, AdminDTO>();
            });
           var mapper = new Mapper(config);
            return mapper.Map<List<AdminDTO>>(data);

        }

        public static AdminDTO Get(int id)
        {
            var data = AdminDAF.EmployeeData().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, AdminDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<AdminDTO>(data);
        }

        public static bool Delete(int id)
        {
            var tasks = EmployeeDAF.AssignedTaskData().GetAllById(id);
            foreach (var aTask in tasks)
            {
                ManagerDAF.ATData().ReassignTask(aTask, 1);
            }

            return AdminDAF.EmployeeData().Delete(id);
        }
    }
}
