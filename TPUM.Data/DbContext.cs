using System;
using System.Collections.Generic;
using TPUM.Data.Interfaces;
using TPUM.Data.Model;

namespace TPUM.Data
{
    public sealed class DbContext : DataContext
    {
        private static DbContext instance = null;
        private static readonly object lockobj = new object();
        DbContext()
        {
            Clients = new List<Client>();
            Products = new List<Product>();
            GenerateData();
        }
        public static DbContext Instance
        {
            get
            {
                lock (lockobj)
                {
                    if (instance == null)
                    {
                        instance = new DbContext();
                    }
                }
                return instance;
            }
        }

        private void GenerateData()
        {
            Clients.Add(new Client
            {
                Id = 1,
                DateOfBirth = new DateTime(1997, 06, 25),
                Cart = new Cart { Products = new List<Product>() },
                Name = "Jan",
                LastName = "Naj"
            });

            Products.Add(new Product
            {
                Id = 1,
                Author = "DVD Project Blue",
                Name = "Super gra",
                Price = 31.50f,
                AllowedFromDate = new DateTime(1999, 01, 01),
                IsLocked = false
            });

            Products.Add(new Product
            {
                Id = 2,
                Author = "Blueray Project Yellow",
                Name = "Lepsza gra",
                Price = 25.50f,
                AllowedFromDate = new DateTime(1999, 01, 01),
                IsLocked = false
            });

            Products.Add(new Product
            {
                Id = 3,
                Author = "VHS Project Green",
                Name = "Ultra gra",
                Price = 11.50f,
                AllowedFromDate = new DateTime(1999, 01, 01),
                IsLocked = false
            });
        }
    }
}
