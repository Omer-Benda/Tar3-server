using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RecipeController : ApiController
    {
        Cgroup99DBContext db = new Cgroup99DBContext();

        // GET: api/Recipe
        public IHttpActionResult Get()
        {
            List<recipeModels> recList;
            try
            {
                recList = db.Recipes.Select(r => new recipeModels
                {
                    id = r.id,
                    name = r.name,
                    cookingMethod = r.cookingMethod,
                    time = r.time,
                    image = r.image,
                    ingList = r.Ingredient.Select(i => new ingredientsModel { 
                        id = i.id,
                        image = i.image,
                        calories = i.calories,
                        name = i.name }).ToList()
                }).ToList();

                return Ok(recList);

                //return Ok(db.Recipes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Recipe/6
        public string Get(int id)
        {
            return "value";
        }

       [HttpPost]
       [Route("api/createrecipe")]
        public IHttpActionResult Post([FromBody]recipeModels value)
        {
            try
            {
                recipeModels i = value;
                Recipes x = new Recipes();
                x.name = i.name;
                x.image = i.image;
                x.time = i.time;
                x.cookingMethod = i.cookingMethod;

                List<Ingredient> ing = new List<Ingredient>();
                foreach (ingredientsModel item in i.ingList)
                {
                    ing.Add(db.Ingredient.FirstOrDefault(y => y.id == item.id));
                }

                x.Ingredient = ing;
                db.Recipes.Add(x);
                db.SaveChanges();
                return Ok();

                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        // PUT: api/Recipe/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Recipe/5
        public void Delete(int id)
        {
        }
    }
}
