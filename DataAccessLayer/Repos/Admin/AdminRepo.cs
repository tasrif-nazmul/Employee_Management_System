using DataAccessLayer.EF;
using DataAccessLayer.EF.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repos.Admin
{
    public class AdminRepo
    {
        public static List<Employee> GetAll()
        {
              var db = new DatabaseContext();
            
             return db.Employees.ToList();

         /*   var bigCities = new List<string>()
                    {
                        "New York",
                        "London",
                        "Mumbai",
                        "Chicago"
                    };

            return bigCities;
         
            */
        }
    }
}
