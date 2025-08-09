using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PizzaStore_MinAPI_EFCore;

//this project is using Minimal APIs with Entity Framework Core to create a simple pizza store API
// its using SQLite as the database to store pizza data

var builder = WebApplication.CreateBuilder(args);

// This line adds services to the container for dependency injection in the application.
builder.Services.AddEndpointsApiExplorer();

// This line adds a database context for the PizzaDb using SQLite with a file named "pizzastore.db".
// This is where the pizza data will be stored persistently in a SQLite database file.
// builder.Services.AddDbContext<PizzaDb>(options => options.UseSqlite("Data Source=pizzastore.db"));

// This line adds a database context for the PizzaDb using an in-memory database named "items".
// This is useful for testing or development purposes where you don't need a persistent database.
//builder.Services.AddDbContext<PizzaDb>(options => options.UseInMemoryDatabase("items"));


//adding the connection string for the SQLite database
var connectionString = builder.Configuration.GetConnectionString("Pizzas") ??
    "Data Source = Pizzas.db";

// This line adds a database context for the PizzaDb using SQLite with the specified connection string.
// The connection string is retrieved from the configuration, and if not found, it defaults to "Pizzas.db".
builder.Services.AddSqlite<PizzaDb>(connectionString);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PizzaStore API",
        Description = "Making the Pizzas you love",
        Version = "v1"
    });
});

var app = builder.Build();

if ( app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaStore API V1");
    });
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/pizzas", async (PizzaDb db) => await db.Pizzas.ToListAsync());

//POST METHOD to post new items to the pizzas list
// "/pizzas" is the endpoint where the new pizza will be posted.
// PizzaDb db is the database context that provides access to the Pizzas table in the SQLite database.
// Pizza pizza is the parameter(data) representing a pizza that is going to be created with properties like Id, Name, and Description.
app.MapPost("/pizzas", async (PizzaDb db, Pizza pizza) =>
{
    // This line connects to the database and adds the new pizza object where the details of the new pizza are store by now to the Pizzas table.
    await db.Pizzas.AddAsync(pizza);
    // This line saves the changes to the database, which means it will insert the new pizza into the Pizzas table.
    await db.SaveChangesAsync();
    //this line returns a 201 Created response with the location of the newly created pizza resource and the pizza object itself.
    // The location is set to "/pizzas/{pizza.Id}" where {pizza.Id} is the unique identifier of the newly created pizza.
    // The pizza object is returned in the response body, which contains the details of the newly created pizza.
    return Results.Created($"/pizzas/{pizza.Id}", pizza);
});

//GET METHOD to get a specific pizza by its ID
app.MapGet("/pizzas/{id}", async (PizzaDb db, int id) => await db.Pizzas.FindAsync(id));
// This line defines a GET endpoint at "/pizzas/{id}" where {id} is a placeholder for the pizza's unique identifier.
// The method takes two parameters: PizzaDb db, which is the database context, and int id, which is the ID of the pizza to be shown.
//async to say that this method might take some time to complete, especially if it involves database operations. So dont block the entiry program whie waiting the result
// int id is the variable that will hold the ID of the pizza we want to retrieve from the database.
// FindAsync(id) is a method that searches for a pizza with the specified ID in the Pizzas table of the database. It returns the pizza if found or null if not found.

// PUT METHOD to update an existing pizza
app.MapPut("/pizzas/{id}", async (PizzaDb db, int id, Pizza updatedPizza) =>
{
    //pizzaToUpdate is a variable that will hold the pizza object to edit retrieved from the database using the provided id
    var pizzaToUpdate = await db.Pizzas.FindAsync(id);
    
    if(pizzaToUpdate is null)
    {
        return Results.NotFound($"Pizza with ID {id} not found"); // If the pizza with the specified ID is not found, return a 404 Not Found response.
    };

    // If the pizza is found, update its properties with the values from the updatePizza object.
    pizzaToUpdate.Name = updatedPizza.Name;
    pizzaToUpdate.Description = updatedPizza.Description;

    // Save the changes to the database using SaveChangesAsync method.
    await db.SaveChangesAsync();
    //return a 200 OK response with the updated pizza object.
    return Results.Ok(pizzaToUpdate);
});

// DELETE METHOD to delete a pizza by its ID
app.MapDelete("pizzas/{id}", async (PizzaDb db, int id) =>
{
    //pizzaToDelete is a variable that will hold the pizza object to delete retrieved from the database using the provided id
    var pizzaToDelete = await db.Pizzas.FindAsync(id);

    if(pizzaToDelete is null)
    {
        return Results.NotFound($"Pizza with ID {id} not found"); // If the pizza with the specified ID is not found, return a 404 Not Found response.
    }

    db.Pizzas.Remove(pizzaToDelete); // If the pizza is found, remove it from the Pizzas table using the Remove method.
    await db.SaveChangesAsync(); // Save the changes to the database using SaveChangesAsync method.
    return Results.Ok("Pizza deleted successfully"); // Return a 200 OK response with a success message.    
});

app.Run();
