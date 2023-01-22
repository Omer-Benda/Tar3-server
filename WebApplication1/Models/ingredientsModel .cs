using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ingredientsModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public int calories { get; set; }

        public override string ToString()
        {
            return $"id={id}, name={name}, image={image}, calories={calories}";
        }

    }
}