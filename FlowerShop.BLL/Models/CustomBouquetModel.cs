using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models
{
    public class CustomBouquetModel
    {
        public const int MaxPhotoSize = 4 * 1024 * 1024;
        public const int MaxUserDescriptionLenght = 1000;
        private CustomBouquetModel(Guid id, byte[]? photo, Guid userId, string? userDescription, DateTime requestTime)
        {
            Id = id;
            Photo = photo;
            UserId = userId;
            UserDescription = userDescription;
            RequestTime = requestTime;
        }

        public Guid Id { get; }
        public byte[]? Photo { get; }
        public Guid UserId { get; }
        public string? UserDescription { get; }
        public DateTime RequestTime { get; }

        public static (CustomBouquetModel, string Error) Create(Guid id, byte[]? photo, Guid userId, string? userDescription, DateTime requestTime)
        {
            var error = string.Empty;

            if(id == Guid.Empty)
            {
                error = "CustomBouquet Id error";
            }

            if (photo == null || photo.Length > MaxPhotoSize)
            {
                error = "Photo is empty or more than 4 MB";
            }

            if(userId == Guid.Empty)
            {
                error = "CustomBouquet User Id error";
            }

            if(userDescription?.Length > MaxUserDescriptionLenght)
            {
                error = "Description more than 1000 symbols";
            }

            var customBouquet = new CustomBouquetModel(id, photo, userId, userDescription, requestTime);

            return (customBouquet, error);
        }
    }
}
