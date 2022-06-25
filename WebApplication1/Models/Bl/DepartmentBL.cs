using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DepartmentBL
    {
        FactoryEntities1 depBL = new FactoryEntities1();

        public List<Department1> GetAll()
        {
            return depBL.Department1.ToList();
        }
    }
}

