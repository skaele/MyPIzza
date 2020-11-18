using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyPizza.Abstractions
{
    public abstract class Dish 
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int ImageId { get; set; }

        public double Raitng { get; set; }
        
        public string Description { get; set; }

        /// <summary>
        /// JSON like {"S", "M"} 
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// JSON like {"100", "200"} 
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Dishes.Size is array of strings recorded as JSON
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="dishes"></param>
        /// <returns>Dictionary<id, sizes></returns>
        public static Dictionary<int, List<string>> GetSizesOfDishes(List<Dish> dishes)
        {
            Dictionary<int, List<string>> dishesSizes = new Dictionary<int, List<string>>();

            foreach (var dish in dishes)
            {
                dishesSizes[dish.Id] = JsonConvert.DeserializeObject<List<string>>(dish.Size);
            }

            return dishesSizes;
        }

        /// <summary>
        /// Dishes.Price is array of integers recorded as JSON
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="dishes"></param>
        /// <returns>Dictionary<id, prices></returns>
        public static Dictionary<int, List<int>> GetPricesOfDishes(List<Dish> dishes)
        {
            Dictionary<int, List<int>> dishesPrices = new Dictionary<int, List<int>>();

            foreach (var dish in dishes)
            {
                dishesPrices[dish.Id] = JsonConvert.DeserializeObject<List<int>>(dish.Price);
            }

            return dishesPrices;
        }
    }
}
