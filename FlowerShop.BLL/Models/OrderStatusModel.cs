using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models
{
    public class OrderStatusModel
    {
        public const int MaxNameLenght = 255;

        private OrderStatusModel(int id, string? name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string? Name { get; }

        public static (OrderStatusModel, string Error) Create(int id, string? name)
        {
            var error = string.Empty;

            if (id == 0)
            {
                error = "Order Id error";
            }

            if (string.IsNullOrWhiteSpace(name) || name.Length > MaxNameLenght)
            {
                error = "Name is null, empty or more than 255 symbols";
            }

            var orderStatus = new OrderStatusModel(id, name);

            return (orderStatus, error);
        }
    }
}
