using FlowerShop.DAL.Data;
using FlowerShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.DAL
{
    public class SeedData
    {
        public static void Initialize(FlowerDbContext context)
        {
            string solutionDirectory = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            string projectDirectory = Path.Combine(solutionDirectory, "FlowerShop.DAL");
            string imagePath = Path.Combine(projectDirectory, "SeedImages");


            var categories = new List<Category>()
            {
                new Category { Id =  Guid.NewGuid(), Name = "Category1" },
                new Category { Id =  Guid.NewGuid(), Name = "Category2" },
            };

            var items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid(), Name = "Троянда", Description = "Емблема кохання та краси, троянда має безліч сортів і кольорів, від яскравих червоних до ніжних білих",
                    CategoryId = categories[0].Id, Price = 80, Photo = File.ReadAllBytes($"{imagePath}/Rose.jpg")},

                new Item { Id = Guid.NewGuid(), Name = "Лілія", Description = "Символ чистоти та величі, лілія має елегантні квіти з великими квітками, які можуть бути різноманітних кольорів",
                    CategoryId = categories[0].Id, Price = 50, Photo = File.ReadAllBytes($"{imagePath}/Lily.jpg")},

                new Item { Id = Guid.NewGuid(), Name = "Хризантема", Description = "Ця квітка асоціюється з довгим життям та щастям. Вона має велику різноманітність форм і відтінків",
                    CategoryId = categories[0].Id, Price = 30, Photo = File.ReadAllBytes($"{imagePath}/Chrysanthemum.jpg")},

                new Item { Id = Guid.NewGuid(), Name = "Георгіна", Description = "Георгіни вражають своєю різноманітністю кольорів та форм квіток, від яскравих до пастельних",
                    CategoryId = categories[1].Id, Price = 40, Photo = File.ReadAllBytes($"{imagePath}/Georgina.jpg")},

                new Item { Id = Guid.NewGuid(), Name = "Волошка", Description = "Це скромна квітка, але вона символізує простоту та ніжність, часто зустрічається в дикій природі",
                    CategoryId = categories[1].Id, Price = 20, Photo = File.ReadAllBytes($"{imagePath}/Cornflower.jpg")},

                new Item { Id = Guid.NewGuid(), Name = "Орхідея", Description = "Елегантна та загадкова, орхідея представляє різноманітність форм і кольорів і вважається символом краси та розкіші",
                    CategoryId = categories[1].Id, Price = 200, Photo = File.ReadAllBytes($"{imagePath}/Orchid.jpg")},
            };

            var orderStatuses = new List<OrderStatus>()
            {
                new OrderStatus { Id = 1, Name = "Created by User"},
                new OrderStatus { Id = 2, Name = "Confirmed by Shop"},
                new OrderStatus { Id = 3, Name = "Order placed"},
                new OrderStatus { Id = 4, Name = "Arrived"},
                new OrderStatus { Id = 5, Name = "Received"},
                new OrderStatus { Id = 10, Name = "Canceled"},
            };

            bool saveChange = false;

            if(!context.OrderStatuses.Any())
            {
                context.OrderStatuses.AddRange(orderStatuses);

                saveChange = true;
            }

            if(!context.Categories.Any() && !context.Items.Any())
            {
                context.Categories.AddRange(categories);
                context.Items.AddRange(items);

                saveChange = true;
            }

            if (saveChange)
            {
                context.SaveChanges();
            }
        }
    }
}
