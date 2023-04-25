using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Context
{
    public class WebContext : DbContext
    {
        public DbSet<Brend> Brends { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<GoodImage> GoodsImage { get; set; }
        public WebContext() : base() { }
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        { }

        public async Task Initial()
        {
            await Brends.AddRangeAsync(new Brend[]
            { new() { Name="Duracell" },
                 new() { Name="Sony" },
                  new() { Name="Varta" },
                  new() { Name="Panasonic" },
            });
            await GoodsImage.AddRangeAsync(new GoodImage[]
                { new() { Path="Image/dur1.webp" },
                 new() { Path = "Image/dur.webp" },
                  new() { Path = "Image/pan.webp" },
                  new() { Path = "Image/var.webp" },
            });
            await SaveChangesAsync();
            await Categories.AddRangeAsync(new Category[] {
                new (){Name="Батарейки", Image=GoodsImage.First()},
                new (){Name="Акумулятори", Image=GoodsImage.Skip(1).First()},
                new (){Name="Зарядні",Image=GoodsImage.Skip(2).First()}
            });
            await SaveChangesAsync();
            for(int i = 0; i < 3; i++)
            {
                var cat = Categories.Skip(i).First();
                for (int y = 0; y <4 ; y++)
                {
                    var br=Brends.Skip(y).First();
                    var im = GoodsImage.Skip(y).First();
                    for (int z = 0; z < 5; z++)
                    {
                        Good g = new()
                        {
                            Name = $"{cat.Name} {br.Name} {z}",
                            Category=cat, GoodImage= im , Brend=br,
                            Price=z*3
                        };
                        await Goods.AddAsync(g);
                    }
                }
                 
            }
            await SaveChangesAsync();
        }

    }
}
