using AdBoard.Models;
using AdBoard.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AdBoard.Models
{
    public static class AdModel
    {
        public static IEnumerable<Ad> Search(string type, string searchString)
        {
           
            if (!String.IsNullOrEmpty(type))
            {
                type.Remove(0);
                if (type.Contains("Продам"))
                {
                    type = "1";
                }
                else
                {
                    type = "2";
                }
            }
            var ads = from ad in AdModel.GetAllAds() select ad;

            if (!String.IsNullOrEmpty(searchString))
            {
                ads = ads.Where(s => s.Title.Contains(searchString) || s.Text.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(type))
            {
                ads = ads.Where(s => s.AdTypeId == Convert.ToInt32(type));
            }
            return ads;
        }
        public static Ad[] GetAllAds()
        {
            var entity = new AdBoardEntities();

            return entity.Ads.Where(a => a.IsPublic).ToArray();
        }
        public static Ad[] GetAllAdsForVerification()
        {
            var entity = new AdBoardEntities();

            return entity.Ads.ToArray();
        }
        public static Ad[] GetAdsByUserId(int userId)
        {
            var entity = new AdBoardEntities();

            return entity.Ads.Where(a => a.UserId == userId).ToArray();
        }

        public static void AddAd(Ad ad, User user)
        {
            var entity = new AdBoardEntities();
            ad.IsPublic = false; //unpublic, waiting verification by admin
            ad.CreateDate = DateTime.Now; // current time
            ad.UserId = user.Id; // user, whom place ad
            entity.Ads.Add(ad);
            entity.SaveChanges();
        }
        public static Ad GetAdById(int id)
        {
            var entity = new AdBoardEntities();

            return entity.Ads.FirstOrDefault(a => a.Id == id);
        }
        public static void RemoveAd(int id)
        {
            var entity = new AdBoardEntities();

            Ad ad = entity.Ads.FirstOrDefault(a => a.Id == id);
            var adForDeletingImages = AdModel.GetAdById(id);
            foreach (var image in adForDeletingImages.Images)
            {
                ImageModel.RemoveImage(image.Id);
            }
            if (ad != null)
            {
                entity.Ads.Remove(ad);
                entity.SaveChanges();
            }
        }
        public static void AdVerification(int id)
        {
            var entity = new AdBoardEntities();
            entity.Ads.FirstOrDefault(a => a.Id == id).IsPublic = !entity.Ads.FirstOrDefault(a => a.Id == id).IsPublic;
            entity.SaveChanges();
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
        public static void RemoveAd(Ad ad, User user)
        {
            if (ad != null && ad.UserId == user.Id)
            {
                foreach (var item in ad.Images)
                {
                    Helpers.ImageHelper.DeleteFile(item.LargeImage);
                    Helpers.ImageHelper.DeleteFile(item.SmallImage);

                    ImageModel.RemoveImage(item);
                }

                AdModel.RemoveAd(ad.Id);
            }
        }
    }
}