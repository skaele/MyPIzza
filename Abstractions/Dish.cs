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
        /// string like "Water, apple, orange"
        /// </summary>
        public string Composition { get; set; }

        /// <summary>
        /// JSON like "['S', 'M']" or "[25, 30, 35]"
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// JSON like "[100, 200]" 
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Dishes.Size is array of strings
        /// As key use Type_id 
        /// example: Pizza_1
        /// </summary>
        /// <param name="dishes"></param>
        /// <returns>Dictionary<Type_id, sizes></returns>
        public static Dictionary<string, List<string>> GetSizesOfDishes(List<Dish> dishes)
        {
            Dictionary<string, List<string>> dishesSizes = new Dictionary<string, List<string>>();

            foreach (var dish in dishes)
            {
                string typeOfDish = dish.GetType().ToString().Split('.').Last() + '_';

                dishesSizes[typeOfDish + dish.Id] = JsonConvert.DeserializeObject<List<string>>(dish.Size);
            }

            return dishesSizes;
        }

        /// <summary>
        /// Dishes.Price is array of integers 
        /// As key use Type_id 
        /// example: Pizza_1
        /// </summary>
        /// <param name="dishes"></param>
        /// <returns>Dictionary<Type_id, prices></returns>
        public static Dictionary<string, List<int>> GetPricesOfDishes(List<Dish> dishes)
        {
            Dictionary<string, List<int>> dishesPrices = new Dictionary<string, List<int>>();


            foreach (var dish in dishes)
            {
                string typeOfDish = dish.GetType().ToString().Split('.').Last() + '_';

                dishesPrices[typeOfDish + dish.Id] = JsonConvert.DeserializeObject<List<int>>(dish.Price);
            }

            return dishesPrices;
        }
    }
}
