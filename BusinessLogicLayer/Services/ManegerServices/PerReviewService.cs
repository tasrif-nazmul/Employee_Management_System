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
    public class PerReviewService
    {
        public static List<PerformanceReviewDTO> GetAll(int id)
        {
            var data = ManagerDAF.PerReviewData().GetAll();
            var data2 = data.Where(t => t.EmployeeID.Equals(id)).ToList();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PerformanceReview, PerformanceReviewDTO>();
            });

            var mapper = new Mapper(config);
            var mapped = mapper.Map<List<PerformanceReviewDTO>>(data2);
            return mapped;
        }

        public static bool Create(PerformanceReviewDTO pr)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PerformanceReviewDTO, PerformanceReview>();
            });

            var mapper = new Mapper(config);
            var data = mapper.Map<PerformanceReview>(pr);
            return ManagerDAF.PerReviewData().Create(data);
        }

        public static bool delete(int id)
        {
            return ManagerDAF.PerReviewData().Delete(id);
        }


    }
}
