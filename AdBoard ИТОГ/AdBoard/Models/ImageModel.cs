using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdBoard.Models
{
    public static class ImageModel
    {
        public static void UploadImage(Image image)
        {
            var entity = new AdBoardEntities();

            entity.Images.Add(image);
            entity.SaveChanges();
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
        public static void RemoveImage(int id)
        {

            Image image = ImageModel.GetImageById(id);

            if (image != null)
            {
                Helpers.ImageHelper.DeleteFile(image.LargeImage);
                Helpers.ImageHelper.DeleteFile(image.SmallImage);
                ImageModel.RemoveImage(image);
            }
        }
        public static void RemoveImage(Image image, User user)
        {
            if (image != null && image.Ad.UserId == user.Id)
            {
                Helpers.ImageHelper.DeleteFile(image.LargeImage);
                Helpers.ImageHelper.DeleteFile(image.SmallImage);
                ImageModel.RemoveImage(image);
            }
        }
        public static Image GetImageById(int id)
        {
            var entity = new AdBoardEntities();

            return entity.Images.FirstOrDefault(i => i.Id == id);
        }

    }
}