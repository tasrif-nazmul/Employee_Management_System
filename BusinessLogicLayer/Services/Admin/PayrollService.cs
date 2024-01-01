using AutoMapper;
using BusinessLogicLayer.DTOs.AdminDTOs;
using DataAccessLayer.DAF;
using DataAccessLayer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Admin
{
    public class PayrollService
    {
        public static bool Add(PayrollDTO obj)
        {
            decimal taxAmount = CalculateTaxAmount(obj.GrossSalary);
            decimal netSalary = Math.Round(obj.GrossSalary - taxAmount, 2);
            decimal bonus = CalculateBonus(obj.EmployeeID, obj.GrossSalary);
            

            var payrollDetails = new PayrollDTO
            {
                EmployeeID = obj.EmployeeID,
                GrossSalary = Math.Round(obj.GrossSalary, 2),
                NetSalary = netSalary,
                TaxAmount = taxAmount,
                PayDate = obj.PayDate,
                Bonus = bonus
            };

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<PayrollDTO, Payroll>();
            });
            var mapper = new Mapper(config);
            var mapped = mapper.Map<Payroll>(payrollDetails);
            return AdminDAF.PayrollData().Add(mapped);
        }


        private static decimal CalculateTaxAmount(decimal grossSalary)
        {
            const decimal taxRate = 0.20m;
            return Math.Round(grossSalary * taxRate, 2);
        }

        private static decimal CalculateBonus(int employeeId, decimal grossSalary)
        {
            string ratings = ManagerDAF.PerReviewData().GetRatings(employeeId);

            if (String.IsNullOrEmpty(ratings))
            {
                decimal bonus = 0.00m;
                return bonus;
            }
            else
            {
                decimal number = decimal.Parse(ratings);

                decimal bonus = (number / 100) * grossSalary;

                return Math.Round(bonus, 2);
            }

        }
    }
}
