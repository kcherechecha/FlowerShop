using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models
{
    public class OrderModel
    {
        public const int MaxAdressLenght = 255;
        private OrderModel(Guid id, string? orderAddress, string phoneNumber, decimal orderPrice, DateTime orderTime, Guid userId, int orderStatusId)
        {
            Id = id;
            OrderAddress = orderAddress;
            PhoneNumber = phoneNumber;
            OrderPrice = orderPrice;
            OrderTime = orderTime;
            UserId = userId;
            OrderStatusId = orderStatusId;
        }

        public Guid Id { get; }
        public string? OrderAddress { get; }
        public string PhoneNumber { get; }
        public decimal OrderPrice { get; }
        public DateTime OrderTime { get; }
        public Guid UserId { get; }
        public int OrderStatusId { get; }

        public static (OrderModel, string Error) Create(Guid id, string? orderAddress, 
            string phoneNumber, decimal orderPrice, DateTime orderTime, Guid userId, int orderStatusId)
        {
            var error = string.Empty;

            if (id == Guid.Empty)
            {
                error = "Order Id error";
            }

            if(string.IsNullOrWhiteSpace(orderAddress) || orderAddress.Length > MaxAdressLenght)
            {
                error = "Order Address null, empty or more than 255 symbols";
            }

            if(string.IsNullOrWhiteSpace(phoneNumber) || (phoneNumber.Length != 12 && phoneNumber.Length != 10))
            {
                error = "Phone number is empty or incorrect format";
            }

            if (orderPrice is < 0 or > decimal.MaxValue)
            {
                error = "Order Price range error";
            }

            if(userId ==  Guid.Empty)
            {
                error = "Order User Id error";
            }

            var order = new OrderModel(id, orderAddress, phoneNumber, orderPrice, orderTime, userId, orderStatusId);

            return (order, error);
        }
    }
}
