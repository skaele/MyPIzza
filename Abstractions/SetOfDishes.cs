using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPizza.Abstractions
{
    public abstract class SetOfDishes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// JSON wherein array of "DishInfo" (Type and Id of Dish)
        public string DishesInComposition { get; set; }

        public uint Price { get; set; }

        public double Raitng { get; set; }

        public string Description { get; set; }
    }
}
