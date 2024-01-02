using AutoMapper;
using BusinessLogicLayer.DTOs;
using DataAccessLayer.DAF;
using DataAccessLayer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class AuthService
    {

        public static TokenDTO Authenticate(string email, string password)
        {
            var result = AdminDAF.AuthData().Authenticate(email, password);
            var employeeID = AdminDAF.AuthData().GetEmployeeID(email, password);

            if (result)
            {
                var existingToken = EmployeeDAF.TokenData().GetAll().FirstOrDefault(t => t.EmployeeID == employeeID);

                if (existingToken != null)
                {
                    throw new Exception("Token already exists for this employee.");
                }

                var token = new Token();
                token.EmployeeID = employeeID;
                token.CreateAt = DateTime.Now;
                token.TKey = Guid.NewGuid().ToString();
                var ret = EmployeeDAF.TokenData().Add(token);
                if (ret != null)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(config);
                    return mapper.Map<TokenDTO>(ret);
                }
            }
            return null;
        }


        public static bool IsTokenValid(string tkey)
        {
            var extk = EmployeeDAF.TokenData().Get(tkey);
            if (extk != null && extk.DeletedAt == null)
            {
                return true;
            }
            return false;
        }

        public static bool Logout(string tkey)
        {
            var extk = EmployeeDAF.TokenData().Get(tkey);
            extk.DeletedAt = DateTime.Now;
            var ud = EmployeeDAF.TokenData().Update(extk);
            if (ud != null)
            {
                return true;
            }
            return false;
        }
    }
}
