using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models
{
    public class CategoryModel
    {
        public const int MaxNameLenght = 255;
        private CategoryModel(Guid id, string? name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string? Name { get; }

        public static (CategoryModel, string Error) Create(Guid id, string? name)
        {
            var error = string.Empty;

            if(id == Guid.Empty)
            {
                error = "Category Id error";
            }

            if(string.IsNullOrWhiteSpace(name) || name.Length > MaxNameLenght)
            {
                error = "Name is null, empty or more than 255 symbols";
            }

            var category = new CategoryModel(id, name);

            return (category, error);
        }
    }
}
