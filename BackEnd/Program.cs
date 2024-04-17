using BackEnd;
using BackEnd.Empresa.Services;
using BackEnd.Empresa.Services.Distributed;
using BackEnd.Empresa.Services.Memory;
using BackEnd.Repositories;
using BackEnd.ServiceDependencies;
using BackEnd.ServiceDependencies.WithCache;
using BackEnd.ServiceDependencies.WithDistributedCache;
using BackEnd.Services.WithCache;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//* Lo que debe ir en la clase startup
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ListUsersWithCompanyName>();
builder.Services.AddScoped<ListUsersWithMemoryCache>();
builder.Services.AddScoped<ListUsersWithDistributedCache>();
builder.Services.AddScoped<IListUsersWithCompanyNameDependencies, ListUsersWithCompanyNameDependencies>();
builder.Services.AddScoped<IListUsersWithMemoryCache, ListUsersMemoryCacheServiceDependencies>();
builder.Services.AddScoped<IListUsersWithDistributedCache, ListUsersDistributedCacheServiceDependencies>();
builder.Services.AddScoped<IDistributedEmpresaServicio, BackEnd.Empresa.Services.Distributed.EmpresaServicio>();
builder.Services.AddSingleton<IEmpresaServicio, BackEnd.Empresa.Services.Memory.EmpresaServicio>();

builder.Services.AddDistributedRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "localhost";
});

builder.Services.AddHttpClient("EmpresaMS", client =>
{
    client.BaseAddress = new Uri("https://localhost:7207/");
});






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

