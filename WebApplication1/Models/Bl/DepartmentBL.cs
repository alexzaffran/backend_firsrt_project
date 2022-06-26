using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DepartmentBL
    {
        FactoryEntities1 depBL = new FactoryEntities1();
       

        public List<DepartmentData> GetAllDepartmentsData()
        {

            var DepData = depBL.Department1
                .ToList()
                .Select(x => {
                    var manager = depBL.Employee.Where(y => y.ID == x.Manager).FirstOrDefault();
                    var allEmployee = depBL.Employee.Where(y => y.DepartmentID == x.ID).ToList();
                    var result = new DepartmentData
                    {
                        DepId = x.ID,
                        DepartmentName = x.Name,
                        ManagerFullName = manager?.First_Name + " " + manager?.Last_Name,
                        Employess = allEmployee,
                    };
                    return result;
                    }
                )
                .ToList();


            return DepData.ToList();

        }
        public DepartmentData GetDepById(int depId)
        {
            var DepData = depBL.Department1
                .Where(x=>x.ID == depId)
                .ToList()
                .Select(x => {
                    var manager = depBL.Employee.Where(y => y.ID == x.Manager).FirstOrDefault();
                    var allEmployee = depBL.Employee.Where(y => y.DepartmentID == x.ID).ToList();
                    var result = new DepartmentData
                    {
                        DepId = x.ID,
                        DepartmentName = x.Name,
                        ManagerFullName = manager?.First_Name + " " + manager?.Last_Name,
                        Employess = allEmployee,
                    };
                    return result;
                }
                )
                .FirstOrDefault();


            return DepData;


        }

        public Department1 AddDep (Department1 newDep)
        {
            var newDepartment = new Department1();

            newDepartment.Name = newDep.Name;
            newDepartment.Manager = newDep.Manager;
            var departIsExist = depBL.Department1.Where(x => x.Name.ToLower() == newDep.Name.ToLower()).FirstOrDefault();
            if (departIsExist != null)
            {
                throw new Exception(String.Format("departement name: {0} already exist", newDep.Name));
            }
            depBL.Department1.Add(newDepartment);
            depBL.SaveChanges();

            return newDepartment;
        }

        public void Delete(int depId)
        {
            var department = depBL.Department1.Find(depId);
            depBL.Department1.Remove(department);
            depBL.SaveChanges();
        }
    }
}
        


    


