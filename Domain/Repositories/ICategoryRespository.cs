using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webapi_FreeCodeCamp.Domain.Models;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace webapi_FreeCodeCamp.Domain.Repositories
{
    public interface ICategoryRespository
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}
