using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webapi_FreeCodeCamp.Domain.Models;
using webapi_FreeCodeCamp.Domain.Repositories;
using webapi_FreeCodeCamp.Persistence.Context;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace webapi_FreeCodeCamp.Domain.Models.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRespository
    {
	    public CategoryRepository(AppDbContext context) : base(context)
        {

	    }

//¿?¿?
/*Notice how simple it is to implement the listing method. 
    * We use the Categories database set to access the categories table and then call the extension method ToListAsync, 
    * which is responsible for transforming the result of a query into a collection of categories.*/
        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categorias.ToListAsync();
        }
    }
}
