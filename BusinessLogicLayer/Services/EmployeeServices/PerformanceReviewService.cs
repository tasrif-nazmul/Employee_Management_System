using AutoMapper;
using BusinessLogicLayer.DTOs.EmployeeDTOs;
using DataAccessLayer.DAF;
using DataAccessLayer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.EmployeeServices
{
    public class PerformanceReviewService
    {
        public static EmployeePerformanceDTO GetEmployeeWithPerformance(int employeeId)
        {
            var employeeData = AdminDAF.EmployeeData().Get(employeeId);
            if (employeeData == null)
            {
                return null;
            }
            var performReview = ManagerDAF.PerReviewData().GetAll().Where(t => t.EmployeeID.Equals(employeeId)).ToList();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeePerformanceDTO>();

                cfg.CreateMap<PerformanceReview, PerformanceReviewDTO>();
            });

            var mapper = new Mapper(config);

            var employeePerform = mapper.Map<EmployeePerformanceDTO>(employeeData);
            employeePerform.performanceReviews = mapper.Map<List<PerformanceReviewDTO>>(performReview);

            return employeePerform;
        }
    }
}
