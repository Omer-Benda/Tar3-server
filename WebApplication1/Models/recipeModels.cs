using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class recipeModels
    {

        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string cookingMethod { get; set; }
        public string time { get; set; }
        

        public List<ingredientsModel> ingList;

    }
}