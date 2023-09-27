
using DecoratorPatternNetCore.Data;
using DecoratorPatternNetCore.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration;

builder.Services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

builder.Services.AddMemoryCache();

builder.Services.AddScoped<IMemberRepository>(provider => {
    var context = provider.GetService<DatabaseContext>();
    var cache = provider.GetService<IMemoryCache>();

    return new CachingMemberRepository(
         new MemberRepository(context),
         cache);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
