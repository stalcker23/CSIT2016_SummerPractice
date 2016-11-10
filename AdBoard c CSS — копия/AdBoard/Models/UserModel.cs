using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AdBoard.ViewModels;
using System.Web.Http;

namespace AdBoard.Models
{
    public static class UserModel
    {
       
        public static User GetUser(string email, string password)
        {
            var entity = new AdBoardEntities();

            return entity.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public static void BanUnbanUser(int id)
        {
            var entity = new AdBoardEntities();
            entity.Users.FirstOrDefault(u => u.Id == id).IsBlock=!(entity.Users.FirstOrDefault(u => u.Id == id).IsBlock); 
            entity.SaveChanges();
        }
        public static User GetUserByCookeis(string cookies)
        {
            var entity = new AdBoardEntities();

            return entity.Users.FirstOrDefault(u => u.Cookies == cookies);
        }

        public static void AddUser(User user)
        {
            var entity = new AdBoardEntities();
            user.RegDate = DateTime.Now; // current time
            user.RoleId = 2; // number 2 - role User (number 1 - Admin)  
            user.Cookies = Guid.NewGuid().ToString(); // cookie for auth
            user.IsBlock = false; // banned acc
            user.Password = Helpers.SecurityHelper.Hash(user.Password);
            entity.Users.Add(user);
            entity.SaveChanges();
        }

        public static AdminViewModel GetAllUsers()
        {
            var users = new AdminViewModel();
            var entity = new AdBoardEntities();
            var allUser = from item in entity.Users select item;
            var items = 
                from item in allUser.ToList()
                where item.RoleId!=1
                select item;
            
            foreach (var item in items)
            {
                 
                users.Users.Add(item);
            }
            return users;
        }



        
       
        
        public static void AdBanUser(int id)
        {
            var entity = new AdBoardEntities();
            entity.Ads.FirstOrDefault(a => a.Id == id).IsPublic = false;
            entity.SaveChanges();
        }
        

       
       
    }
}