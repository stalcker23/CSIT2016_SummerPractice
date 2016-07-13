using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdBoard.Model
{
    public static class DataBase
    {
        public static Ad[] GetAllAds()
        {
            var entity = new AdBoardEntities();

            return entity.Ads.Where(a => a.IsPublic).ToArray();
        }

        public static User GetUser(string email, string password)
        {
            var entity = new AdBoardEntities();

            return entity.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public static User GetUserByCookeis(string cookies)
        {
            var entity = new AdBoardEntities();

            return entity.Users.FirstOrDefault(u => u.Cookies == cookies);
        }

        public static void AddUser(User user)
        {
            var entity = new AdBoardEntities();

            entity.Users.Add(user);
            entity.SaveChanges();
        }

        public static Ad[] GetAdsByUserId(int userId)
        {
            var entity = new AdBoardEntities();

            return entity.Ads.Where(a => a.UserId == userId).ToArray();
        }

        public static void AddAd(Ad ad)
        {
            var entity = new AdBoardEntities();

            entity.Ads.Add(ad);
            entity.SaveChanges();
        }

        public static void UploadImage(Image image)
        {
            var entity = new AdBoardEntities();

            entity.Images.Add(image);
            entity.SaveChanges();
        }

        public static Ad GetAdById(int id)
        {
            var entity = new AdBoardEntities();

            return entity.Ads.FirstOrDefault(a => a.Id == id);
        }

        public static void RemoveImage(Image item)
        {
            var entity = new AdBoardEntities();

            Image image = entity.Images.FirstOrDefault(i => i.Id == item.Id);

            if (image != null)
            {
                entity.Images.Remove(image);

                entity.SaveChanges();
            }
        }

        public static void RemoveAd(int id)
        {
            var entity = new AdBoardEntities();

            Ad ad = entity.Ads.FirstOrDefault(a => a.Id == id);

            if (ad != null)
            {
                entity.Ads.Remove(ad);

                entity.SaveChanges();
            }
        }

        public static void UpdateAd(Ad ad)
        {
            var entity = new AdBoardEntities();

            Ad _ad = entity.Ads.FirstOrDefault(a => a.Id == ad.Id);

            if (_ad != null)
            {
                _ad.Text = ad.Text;
                _ad.Title = ad.Title;
                _ad.AdTypeId = ad.AdTypeId;

                entity.SaveChanges();
            }
        }

        public static Image GetImageById(int id)
        {
            var entity = new AdBoardEntities();

            return entity.Images.FirstOrDefault(i => i.Id == id);
        }
    }
}