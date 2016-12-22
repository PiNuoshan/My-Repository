using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data.Entity;

namespace BLL
{
    public class UserManager
    {
        //public void AddUser(Users user)
        //{
        //    using (var db = new dbContext())
        //    {
        //        db.Users.Add(user);
        //        db.SaveChanges();
        //    }
        //}
        public static List<ComplainRecord> GetUsers()
        {
            using (var db = new dbContext())
            {
                return db.Users.OrderBy(m => m.Id).ToList();
            }
        }
        public static int GetCount()
        {
            using (var db = new dbContext())
            {
                return db.Users.Count();
            }
        }
        public static List<ComplainRecord> OrderUserByKey(string key)
        {
            using (var db = new dbContext())
            {
                switch (key)
                {
                    case "Id":
                        return db.Users.OrderBy(m => m.Id).ToList();
                    case "Name":
                        return db.Users.OrderBy(m => m.Name).ToList();
                    case "Info":
                        return db.Users.OrderBy(m => m.Info).ToList();
                    case "Phone":
                        return db.Users.OrderBy(m => m.Phone).ToList();
                    default:
                        return db.Users.OrderBy(m => m.Id).ToList();
                }

            }
        }
        public static List<ComplainRecord> GetUsersByKey(string key)
        {
            using (var db = new dbContext())
            {
                var user = from u in db.Users
                           where u.Name.Contains(key) || u.Phone.Contains(key) || u.Info.Contains(key)
                           select u;
                return user.ToList();
            }
        }
        public static ComplainRecord GetUserById(int id)
        {
            using (var db = new dbContext())
            {
                var user = from u in db.Users
                           where u.Id == id
                           select u;
                return user.ToList()[0];
            }
        }
        public static void DeleteUserById(int id)
        {
            using (var db = new dbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }
        public static void AddUser(ComplainRecord user)
        {
            using (var db = new dbContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
