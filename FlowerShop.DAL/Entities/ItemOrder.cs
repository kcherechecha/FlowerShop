﻿namespace FlowerShop.DAL.Entities
{
    public class ItemOrder
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public Item? Item { get; set; }
        public Order? Order { get; set; }
    }
}
