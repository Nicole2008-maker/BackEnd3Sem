using ConnectPlus.BdContextConnect;
using ConnectPlus.Interface;
using ConnectPlus_Moura.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Contexto do banco de dados
builder.Services.AddDbContext<ConnecContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaltConnection")));


builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<ITipoContatoRepository, TipoContatoRepository>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ConnectPlus API",
        Description = "API para gerenciamento de contatos",
        Contact = new OpenApiContact
        {
            Name = "Nicole Samara",
            Url = new Uri("https://www.linkedin.com/in/nicole-samara-huam%C3%A1n-martins-0696993b8/")
        }
    });
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseStaticFiles();
app.MapControllers();

app.Run();