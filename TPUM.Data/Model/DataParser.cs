using System;
using System.Collections.Generic;
using System.Text;

namespace TPUM.Data.Model
{
    public static class DataParser
    {
        public static Client ParseClient(string message)
        {
            int w = 0;
            string getId, getName, getLName, getAge, sign;
            getId = getName = getLName = getAge = sign = "";

            foreach (char c in message)
            {
                if (c != ':')
                {
                    sign += c;
                }
                else
                {
                    w++;

                    if (w == 1)
                    {
                        getId = sign;
                    }
                    else if (w == 2)
                    {
                        getName = sign;
                    }
                    else if (w == 3)
                    {
                        getLName = sign;
                    }

                    sign = "";
                }
            }
            getAge = sign;

            Client client = new Client();
            client.Id = int.Parse(getId);
            client.Name = getName;
            client.LastName = getLName;
            DateTime dateTime = new DateTime(DateTime.Today.Year - int.Parse(getAge), 1, 1);
            client.DateOfBirth = dateTime;
            client.Cart = new Cart { Products = new List<Product>() };

            return client;
        }

        public static Product ParseProduct(string message)
        {
            int w = 0;
            string getId, getName, getAuthor, getPrice, getDate, sign;
            getId = getName = getAuthor = getPrice = getDate = sign = "";

            foreach (char c in message)
            {
                if (c != ':')
                {
                    sign += c;
                }
                else
                {
                    w++;

                    if (w == 1)
                    {
                        getId = sign;
                    }
                    else if (w == 2)
                    {
                        getName = sign;
                    }
                    else if (w == 3)
                    {
                        getAuthor = sign;
                    }
                    else if (w == 4)
                    {
                        getPrice = sign;
                    }

                    sign = "";
                }
            }
            getDate = sign;

            Product product = new Product();
            product.Id = int.Parse(getId);
            product.Name = getName;
            product.Author = getAuthor;
            product.Price = float.Parse(getPrice);
            DateTime dateTime = DateTime.Today;
            product.AllowedFromDate = dateTime;

            return product;
        }
    }
}
