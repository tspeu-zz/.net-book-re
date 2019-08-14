using System;
using webapi_FreeCodeCamp.Persistence.Context;

/// <summary>
/// This class is just an abstract class that all our repositories will inherit. 
/// An abstract class is a class that don’t have direct instances.
/// You have to create direct classes to create the instances.
/// </summary>
/// 
namespace webapi_FreeCodeCamp.Domain.Models.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

	    public BaseRepository(AppDbContext context)
	    {
            _context = context;
	    }
    }
}
