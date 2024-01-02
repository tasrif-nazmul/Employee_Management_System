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
    public class PayrollService
    {
        public static List<PayrollDTO> SearchPayrollData(PayrollDTO obj)
        {
            var allPayrollData = EmployeeDAF.PRoleData().GetAll();
            var filterPayrollData = allPayrollData.Where(p=> p.EmployeeID == obj.EmployeeID && p.PayDate == obj.PayDate);
           

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Payroll, PayrollDTO>();
            });

            var mapper = new Mapper(config);

            var result = mapper.Map<List<PayrollDTO>>(filterPayrollData);

            return result;
        }


        public static PayslipDTO GetPaySlip(int employeeId)
        {
            var employee = AdminDAF.EmployeeData().Get(employeeId);

            if (employee != null)
            {
                var payroll = EmployeeDAF.PRoleData().GetAll().FirstOrDefault(e => e.EmployeeID == employeeId);

                if (payroll != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Employee, PayslipDTO>();
                        cfg.CreateMap<Payroll, PayslipDTO>();
                    });

                    var mapper = new Mapper(config);

                    var payslip = mapper.Map<PayslipDTO>(employee);
                    mapper.Map(payroll, payslip);

                    payslip.TotalAmount = CalculateTotalAmount(payroll);

                    return payslip;
                }
            }

            return null;
        }

        private static decimal CalculateTotalAmount(Payroll payroll)
        {
            return (decimal)(payroll.GrossSalary + payroll.Bonus - payroll.TaxAmount);
        }



    }
}
