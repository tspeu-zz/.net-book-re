https://www.freecodecamp.org/news/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28/

-We’ll use the Entity Framework Core (I’ll call it EF Core for simplicity) as our database ORM. 
This framework comes with ASP.NET Core as its default ORM and exposes 
a friendly API that allows us to map classes of our applications to database tables.

#The EF Core also allows us to design our application first,
#and then generate a database according to what we defined in our code. 
#This technique is called code first.

# Persistence. This directory is going to have everything we need to access the database, 
#such as repositories implementations.

@la clase debe implementar la interface de EF DbContext
#The constructor we added to this class is responsible for passing 
#the database configuration to the base class through dependency injection
#public class AppDbContext : DbContext
#
#	public AppDbContext(DbContextOptions<AppDbContext> opciones) : base(opciones)
#	
#		

#Also, we have to map the models’ properties to the respective table columns, 
##specifying which properties are primary keys, which are foreign keys, 
#the column types, etc. We can do this overriding the method OnModelCreating, 
#using a feature called Fluent API to specify the database mapping
#
#
https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
We specify to which tables our models should be mapped. Also, we set the primary keys, using the method HasKey, 
the table columns, using the Property method, and some constraints such as IsRequired, 
HasMaxLength, and ValueGeneratedOnAdd, everything with lambda expressions in a “fluent way” (chaining methods).

builder.Entity<Category>()
       .HasMany(p => p.Products)
       .WithOne(p => p.Category)
       .HasForeignKey(p => p.CategoryId);

	specifying a relationship between tables. 
	We say that a category has many products, 
	and we set the properties that will map this relationship
	(Products, from Category class, and Category, from Product class).
	We also set the foreign key (CategoryId).

#TODO
https://www.learnentityframeworkcore.com/relationships
Take a look at this tutorial if you want to learn how to 
configure one-to-one and many-to-many relationships using EF Core,
as well as how to use it as a whole.

The BaseRepository receives an instance of our AppDbContext through dependency injection 
and exposes a protected property (a property that can only be accessible by the children classes) 
called _context, that gives access to all methods we need to handle database operations.

#The EF Core translates our method call to a SQL query, the most efficient way as possible. 
The query is only executed when you call a method that will transform your data into a collection, 
or when you use a method to take specific data.

#Step 6 — Configuring Dependency Injection
The ConfigureServices and Configure methods are called at runtime 
by the framework pipeline to configure how the application should work and which components it must use.

the ConfigureServices method. Here we only have one line, that configures the application to use the MVC pipeline, 
which basically means the application is going to handle requests and responses using controller classes

e ConfigureServices method, accessing the services parameter, to configure our dependency bindings. 

###############################################
services.AddDbContext<AppDbContext>(options => {

  options.UseInMemoryDatabase("supermarket-api-in-memory");
  
});
###############################################

#configure the database context. We tell ASP.NET Core to use our AppDbContext with an in-memory database implementation, 
#that is identified by the string passed as an argument to our method. 
#Usually, the in-memory provider is used when we write integration tests, 
#but I’m using it here for simplicity. This way we don’t need to connect to a real database to test the application.

The scoped lifetime tells the ASP.NET Core pipeline that every time it needs to resolve a class that receives an instance
of AppDbContext as a constructor argument, it should use the same instance of the class. If there is no instance in memory,
the pipeline will create a new instance, and reuse it throughout all classes that need it, during a given request. This way, 
you don’t need to manually create the class instance when you need to use it.

https://docs.microsoft.com/es-ES/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2

After configuring the database context, we also bind our service and repository to the respective classes.

###############################################
services.AddScoped<ICategoryRepository, CategoryRepository>();

services.AddScoped<ICategoryService, CategoryService>();
###############################################

Now that we configure our dependency bindings, we have to make a small change at the Program class, 
in order for the database to correctly seed our initial data.
This step is only needed when using the in-memory database provide

It was necessary to change the Main method to guarantee that our database is going to be “created” 
when the application starts since we’re using an in-memory provider. 
Without this change, the categories that we want to seed won’t be created.

# http://localhost:5000/api/categories

##################################################
dotnet add package AutoMapper

dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
##################################################
To use AutoMapper, we have to do two things:

Register it for dependency injection;
Create a class that will tell AutoMapper how to handle classes mapping.
First of all, open the Startup class. In the ConfigureServices method, after the last line, add the following code:

services.AddAutoMapper();