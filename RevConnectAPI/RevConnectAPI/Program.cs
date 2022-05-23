using RevConnectAPI.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using RevConnectAPI.Data.DataContext;
using RevConnectAPI.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")   
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                      });
});

builder.Services.AddControllers(options =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-d63d2wc5.us.auth0.com/";
    options.Audience = "https://TestRevConnect/api";
});

// Adding Auth0 Config to Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject", Version = "v1.0.0" });

    var securitySchema = new OpenApiSecurityScheme()
    {
        Description = "Using the Authorization header with the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securitySchema);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securitySchema, new[] { "Bearer" } }
    });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("RevConnectPhoto");
//string connection = builder.Configuration.GetConnectionString("Photo");

//sets up blobconfig needed to access blob storage in photoscontroller
builder.Services.AddSingleton<BlobConfig>(_ => new BlobConfig()
{
    _connection = connection
});

builder.Services.AddDbContext<RevConnectContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestRevConnect"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.UseAuthentication();


app.MapControllers();

app.Run();
