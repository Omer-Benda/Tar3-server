using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ingredientsController : ApiController
    {
        EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
  
        Cgroup99DBContext db = new Cgroup99DBContext();

        // GET: api/ingredients
        public IHttpActionResult GetIngredients()
        {
            try
            {
                    List<ingredientsModel> ing;
                    ing = db.Ingredient.Select(i => new ingredientsModel
                    {
                        name = i.name,
                        image = i.image,
                        calories = i.calories,
                        id = i.id
                    }).ToList();
                    return Ok(ing);
              
                //return Ok(db.Ingredient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/ingredients/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ingredients
        public IHttpActionResult AddNewIngredient([FromBody]Ingredient value)
        {
            try
            {
                db.Ingredient.Add(value);
                db.SaveChanges();
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/ingredients/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE: api/ingredients/5
        public void Delete(int id)
        {
        }
    }
}
