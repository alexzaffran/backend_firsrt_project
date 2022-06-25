using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoginBL
    {
        FactoryEntities1 db = new FactoryEntities1();

        //public bool IsUserExist(string User_Name, string Password)
        //{
        //    var result = db.User.Where(x => x.User_Name == User_Name && x.Password == Password);
        //    if (result.Count() > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

            public List<User> Getallusers()
        {
            return db.User.ToList();
        }

        //public User GetUser(int id)
        //{
        //    return db.User.Where(x => x.ID == id).First();
        //}

        public User AddUser(User u)
        {
            User userIsExist = db.User.Where(x => x.User_Name == u.User_Name)
                .FirstOrDefault();

            if (userIsExist != null)
            {
                throw new Exception(String.Format("User {0} already exist", u.User_Name));

            }
            User userSaved = db.User.Add(u);
            db.SaveChanges();
            return userSaved;
        }

        //public void UpdateUser(int id, User u)
        //{
        //    var user = db.User.Where(x => x.ID == id).First();

        //    user.Full_Name = u.Full_Name;
        //    user.User_Name = u.User_Name;
        //    user.Password = u.Password;
        //    user.Num_Of_Actions = u.Num_Of_Actions;
        //    user.C_Actions_Limit = u.C_Actions_Limit;

        //    db.SaveChanges();
        //}

        public User DeleteUser(int id)
        {
            var userFounded = db.User.Where(x => x.ID == id).FirstOrDefault();
            db.User.Remove(userFounded);

            db.SaveChanges();
            return userFounded;
        }

    }
}