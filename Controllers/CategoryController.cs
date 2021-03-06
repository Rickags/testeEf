using System.Collections.Generic;
using System.Threading.Tasks; // TRABALHAR DE FOR ASSINCRONA
using Microsoft.AspNetCore.Mvc;
using apief.Data;
using apief.Models;
using Microsoft.EntityFrameworkCore;

namespace apief.Controllers
{
    [ApiController]
    [Route("v1/categories")]

    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Category>>> Get([FromServices] DataContext context)
        {
            var categories = await context.Categories.ToListAsync();
            return categories;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context,
            [FromBody]Category model)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
    
}