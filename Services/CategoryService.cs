using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webapi_FreeCodeCamp.Domain.Models;
using webapi_FreeCodeCamp.Domain.Repositories;

/// <summary>
/// A service class is not a class that should handle data access. 
/// There is a pattern called Repository Pattern that is used to manage data from databases.
/// </summary>
/// 
namespace webapi_FreeCodeCamp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRespository _categoryRespository;

        public CategoryService(ICategoryRespository categoryRespository)
        {
            this._categoryRespository = categoryRespository;
        }

        public  async Task<IEnumerable<Category>> GetListAsync()
        {
            return await _categoryRespository.ListAsync();
        }
    }
}
