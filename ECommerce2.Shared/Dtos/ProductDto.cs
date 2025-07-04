﻿namespace ECommerce2.Shared.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
    }
}
