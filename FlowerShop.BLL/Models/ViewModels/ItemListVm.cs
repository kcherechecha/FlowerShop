﻿using FlowerShop.BLL.Common.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.BLL.Models.ViewModels
{
    public class ItemListVm
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public byte[]? Photo { get; set; }
    }
}
