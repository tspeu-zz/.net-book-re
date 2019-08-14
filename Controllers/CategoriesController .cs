using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webapi_FreeCodeCamp.Domain.Models;

namespace webapi_FreeCodeCamp.Controllers
{
    /* the underscore prefix is another common convention to denote a field. 
     * This convention, in special, is not recommended by the official naming convention guideline of .NET,
     * but it is a very common practice as a way to avoid having to use the “this” keyword 
     * to distinguish class fields from local variables. 
     */
    [Route("/api/[controller]")]
    public class CategoriesController: Controller
    {   
        // variables
        private readonly ICategoryService _CategoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }

        /*The framework pipeline handles the serialization of data to a JSON object. 
         * The IEnumerable<Category>type tells the framework that we want to return an enumeration of categories,
         * and the Task type, preceded by the async keyword, tells the pipeline that this method should be executed asynchronously. 
         * Finally, when we define an async method, we have to use the await keyword for tasks that can take a while.*/
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllAsync() {

            var categorias = await _CategoryService.GetListAsync();

            return categorias;
        }


    }
}
