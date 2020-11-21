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
        private DishesContext DishesDb { get; }


        public DishesController(DishesContext DishesDb)
        {
            this.DishesDb = DishesDb;
        }

        [HttpGet]
        public IActionResult Main()
        {
            List<Dish> dishes = DishesDb.Dishes;

            ViewBag.DishesSizes = Dish.GetSizesOfDishes(dishes);
            ViewBag.DishesPrices = Dish.GetPricesOfDishes(dishes);

            return View(dishes);
        }

        [HttpGet("[controller]/{dishType:maxlength(10)}/{dishId:int}")]
        public async Task<IActionResult> ConcreteDish(string dishType, int dishId)
        {
            Dish selectedDish = null;
            switch (dishType.ToLower())
            {
                case "pizza":
                    selectedDish = await DishesDb.Pizzas.FirstOrDefaultAsync(p => p.Id == dishId);
                    break;

                case "drink":
                    selectedDish = await DishesDb.Drinks.FirstOrDefaultAsync(p => p.Id == dishId);
                    break;   
            }

            if(selectedDish != null){
                ViewBag.DishSizes = JsonConvert.DeserializeObject<List<string>>(selectedDish.Size);
                ViewBag.DishPrices = JsonConvert.DeserializeObject<List<int>>(selectedDish.Price);
                return View(selectedDish);
            }

            return NotFound();
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> Pizza()
        {
            List<Pizza> pizzas = await DishesDb.Pizzas.ToListAsync();

            ViewBag.PizzasSizes = Dish.GetSizesOfDishes(pizzas.Cast<Dish>().ToList());
            ViewBag.PizzasPrices = Dish.GetPricesOfDishes(pizzas.Cast<Dish>().ToList());

            return View(pizzas);
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> Drink()
        {
            List<Drink> drinks = await DishesDb.Drinks.ToListAsync();
            return View(drinks);
        }

        [HttpGet("[controller]/[action]")]
        public async Task<IActionResult> Combo()
        {
            List<Combo> combos = await DishesDb.Combos.ToListAsync();
            List<List<Dish>> DishesOfCompositions = new List<List<Dish>>();

            foreach (var combo in combos)
            {
                List<Dish> dishesOfThisComp = new List<Dish>();

                //Add dishes of combo as object, in db we have only type and index
                List<DishInfo> dishesInfo = JsonConvert.DeserializeObject<List<DishInfo>>(combo.DishesInComposition);

                foreach (var dishInfo in dishesInfo)
                {
                    switch (dishInfo.Type)
                    {
                        case ("Pizza"):
                            dishesOfThisComp.Add(await DishesDb.Pizzas
                                            .FirstOrDefaultAsync(p => p.Id.ToString() == dishInfo.Id));
                            break;

                        case ("Drink"):
                            dishesOfThisComp.Add(await DishesDb.Drinks
                                            .FirstOrDefaultAsync(p => p.Id.ToString() == dishInfo.Id));
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
