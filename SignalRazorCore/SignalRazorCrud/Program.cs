using Microsoft.EntityFrameworkCore;
using SignalRazorCrud.Data;
using SignalRazorCrud.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddRazorPages(options=>{
    options.RootDirectory = "/Pages";
});

builder.Services.AddDbContext<SchoolContextDBContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContextDBContext")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SchoolContextDBContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}


app.UseStaticFiles();

app.MapRazorPages();
app.Run();
