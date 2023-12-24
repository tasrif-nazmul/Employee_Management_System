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

namespace BusinessLogicLayer.Services.Admin
{
    public class AdminService
    {
        public static List<AdminDTO> GetAll()
        {
            var data = AdminRepo.GetAll();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, AdminDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<AdminDTO>>(data);
        }
    }
}
