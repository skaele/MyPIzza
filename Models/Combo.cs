using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using MyPizza.Abstractions;
using MyPizza.ContextFolder;
using MyPizza.Models;


namespace MyPizza.Models
{
    public class Combo : SetOfDishes
    {
    }
}