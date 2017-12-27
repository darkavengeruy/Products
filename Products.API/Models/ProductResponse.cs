﻿namespace Products.API.Models
{
    using System;
    public class ProductResponse
    {
        public int ProductId { get; set; }
        
        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Precio { get; set; }

        public bool IsActive { get; set; }
        
        public DateTime LastPurchase { get; set; }        

        public double Stock { get; set; }

        public string Remarks { get; set; }
    }
}