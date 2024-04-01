using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models
{
    public class ItemModel
    {
        public const int MaxPhotoSize = 4 * 1024 * 1024;
        public const int MaxNameLenght = 255;
        public const int MaxUserDescriptionLenght = 1000;

        private ItemModel(Guid id, string? name, byte[]? photo, string? description, decimal price, Guid categoryId, string categoryName)
        {
            Id = id;
            Name = name;
            Photo = photo;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public Guid Id { get; }
        public string? Name { get; }
        public byte[]? Photo { get; }
        public string? Description { get; }
        public decimal Price { get; }
        public Guid CategoryId { get; }
        public string CategoryName { get; }

        public static (ItemModel, string Error) Create(Guid id, string? name, byte[]? photo, 
            string? description, decimal price, Guid categoryId, string categoryName)
        {
            var error = string.Empty;

            if (id == Guid.Empty)
            {
                error = "Item Id error";
            }

            if (photo == null || photo.Length > MaxPhotoSize)
            {
                error = "Photo is empty or more than 4 MB";
            }

            if (string.IsNullOrWhiteSpace(name) || name.Length > MaxNameLenght)
            {
                error = "Name is null, empty or more than 255 symbols";
            }

            if (description?.Length > MaxUserDescriptionLenght)
            {
                error = "Description more than 1000 symbols";
            }

            if(price is < 0 or > 1000000)
            {
                error = "Price range is between 0 and 1.000.000";
            }

            if (categoryId == Guid.Empty)
            {
                error = "Item Category Id";
            }

            var item = new ItemModel(id, name, photo, description, price, categoryId, categoryName);

            return (item, error);
        }
    }
}
