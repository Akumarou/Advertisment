﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Advertisement.Application.Services.Ad.Contracts
{
    public static class GetPaged
    {
        public sealed class Request
        {
            public int Offset { get; set; } = 0;
            public int Limit { get; set; } = 10;
        }

        public sealed class Response
        {
            public sealed class Item
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public decimal Price { get; set; }
                public string Status { get; set; }
            }
            
            public int Total { get; set; }
            public int Offset { get; set; } 
            public int Limit { get; set; }

            public IEnumerable<Item> Items { get; set; } = Enumerable.Empty<Item>();
        }
    }
}