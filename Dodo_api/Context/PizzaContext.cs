using System;
using Microsoft.EntityFrameworkCore;

namespace Dodo_api.Models
{
    public class PizzaContext : DbContext
    {
        public PizzaContext (DbContextOptions<PizzaContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        public DbSet<PizzaItem> PizzaItems { get; set; }
        public DbSet<AdditionalItem> AdditionalItems { get; set; }

    }
}
