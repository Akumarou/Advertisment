﻿using System;
using Advertisement.Domain.Shared;

namespace Advertisement.Domain
{
    public sealed class Ad : MutableEntity<int>
    {
        public enum Statuses
        {
            Created,
            Payed,
            Closed
        }
        
        
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public Statuses Status { get; set; }
        
        public int OwnerId { get; set; }
        public User Owner { get; set; }
    }
}
