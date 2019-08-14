using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webapi_FreeCodeCamp.Domain.Models;

/// <summary>
/// Summary interface 
/// The implementations of the ListAsync method must asynchronously return an enumeration of categories.
/// The Task class, encapsulating the return, indicates asynchrony. 
/// We need to think in an asynchronous method due to the fact that we have to wait for the database 
/// to complete some operation to return the data, and this process can take a while. 
/// Notice also the “async” suffix. It’s a convention that indicates that our method should be executed asynchronously.
/// </summary>
/// 

namespace webapi_FreeCodeCamp
{
public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetListAsync();
    }
}
