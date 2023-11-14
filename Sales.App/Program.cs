using Sales.Domain;
using Sales.Domain.Options;
using Sales.Repository.Sales;
using Sales.Services.Sales;

var builder = WebApplication.CreateBuilder(args);

//Option Pattern (DBContext)    
builder.Services.Configure<DBContextOptions>(builder.Configuration.GetSection(key: "MongoConnection"));

builder.Services.AddSingleton<DomainDbContext>();

builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<ISaleRepository, SaleRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
