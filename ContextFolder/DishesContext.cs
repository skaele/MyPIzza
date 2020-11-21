using Microsoft.EntityFrameworkCore;
using MyPizza.Abstractions;
using MyPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPizza.ContextFolder
{
    public class DishesContext : DbContext
    {
        public List<Dish> Dishes
        {
            get
            {
                List<Dish> dishes = new List<Dish>();
                dishes.AddRange(this.Pizzas.ToList<Dish>());
                dishes.AddRange(this.Drinks.ToList<Dish>());

                return dishes;
            }
        }

        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Drink> Drinks { get; set; }

        public DbSet<Combo> Combos { get; set; }

        public DishesContext(DbContextOptions<DishesContext> options) : base(options)
        {
            //Database.EnsureCreated();   
        }

    }
}
