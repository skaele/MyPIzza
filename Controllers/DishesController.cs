using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyPizza.Abstractions;
using MyPizza.ContextFolder;
using MyPizza.SubClasses;
using MyPizza.Models;
using Newtonsoft.Json;

namespace MyPizza.Controllers
{
    public class DishesController : Controller
    {
        //private readonly ILogger<DishesController> logger;

        // public DishesController(ILogger<DishesController> logger)
        // {
        //    _logger = logger;
        // }    

        private DishesContext DishesDb { get; }


        public DishesController(DishesContext DishesDb)
        {
            this.DishesDb = DishesDb;
        }

        public IActionResult Main()
        {
            List<Dish> dishes = DishesDb.Dishes;

            ViewBag.DishesSizes = Dish.GetSizesOfDishes(dishes);
            ViewBag.DishesPrices = Dish.GetPricesOfDishes(dishes);

            return View(dishes);
        }

        public async Task<IActionResult> Pizza()
        {
            List<Pizza> pizzas = await DishesDb.Pizzas.ToListAsync();

            ViewBag.PizzasSizes = Dish.GetPricesOfDishes(pizzas.Cast<Dish>().ToList());
            ViewBag.PizzasPrices = Dish.GetPricesOfDishes(pizzas.Cast<Dish>().ToList());

            return View(pizzas);
        }


        public async Task<IActionResult> Drink()
        {
            List<Drink> drinks = await DishesDb.Drinks.ToListAsync();
            return View(drinks);
        }

        public async Task<IActionResult> Combo()
        {
            List<Combo> combos = await DishesDb.Combos.ToListAsync();
            List<List<Dish>> DishesOfCompositions = new List<List<Dish>>();

            foreach (var combo in combos)
            {
                List<Dish> dishesOfThisComp = new List<Dish>();

                //Add dishes as object, in db we have only type and index
                List<DishInfo> dishesInfo = JsonConvert.DeserializeObject<List<DishInfo>>(combo.DishesInComposition);

                foreach (var dishInfo in dishesInfo)
                {
                    switch (dishInfo.Type)
                    {
                        case ("Pizza"):
                            dishesOfThisComp.Add(DishesDb.Pizzas
                                                 .FirstOrDefault(p => p.Id.ToString() == dishInfo.Index));
                            break;

                        case ("Drink"):
                            dishesOfThisComp.Add(DishesDb.Drinks
                                                 .FirstOrDefault(p => p.Id.ToString() == dishInfo.Index));
                            break;
                    }
                }
                DishesOfCompositions.Add(dishesOfThisComp);
            }

            ViewBag.DishesOfCompositions = DishesOfCompositions;
            return View(combos);
        }
    }
}
