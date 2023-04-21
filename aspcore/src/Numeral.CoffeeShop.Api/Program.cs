using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Numeral.CoffeeShop.Api;
using Numeral.CoffeeShop.Application;
using Numeral.CoffeeShop.EntityFrameworkCore;
using Numeral.CoffeeShop.EntityFrameworkCore.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Numeral Coffee Shop API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder => 
    { 
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod(); 
    });
});
// Add services to the container.
builder.Services
    .AddPresentation()
    .AddApplication(builder.Configuration)
    .AddEntityFrameworkCore(builder.Configuration);


var app = builder.Build();

await app.SeedAsync();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.UseCors("EnableCORS");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
