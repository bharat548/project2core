using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Net.WebRequestMethods;
using System.IO;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Office.CustomUI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace ButchTreat.Data
{
    public class DutchSeeder
    { 
    private readonly DutchContext _ctx;
    private readonly IHostingEnvironment _hosting;
    public  DutchSeeder(DutchContext ctx, IHostingEnvironment hosting){
    _ctx = ctx;
    }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public void seed()
    {
        _ctx.Database.EnsureCreated();

            if (!_ctx.Products.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Date/art.json");
                var json = System.IO.File.ReadAllText(filepath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);
                var orders = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (orders != null)
                {

                    orders.Items = new List<OrderItem>()
                    {

                        new OrderItem()
                        {
                            Product = products.First(),

                             Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                           // Product = Product.First();
                           

                    };
                }
                _ctx.SaveChanges();
        }
    }
}
}