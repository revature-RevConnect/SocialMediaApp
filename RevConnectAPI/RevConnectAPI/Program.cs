using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RevConnectAPI.Database.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

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

    // Test - v1
    //c.SwaggerDoc("v1",
    //    new Microsoft.OpenApi.Models.OpenApiInfo
    //    {
    //        Title = "API",
    //        Version = "v1",
    //        Description = "A REST API",
    //        TermsOfService = new Uri("https://lmgtfy.com/?q=i+like+pie")
    //    });
    //c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    //{
    //    Name = "Authorization",
    //    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
    //    Type = Microsoft.OpenApi.Models.SecuritySchemeType.OAuth2,
    //    Flows = new Microsoft.OpenApi.Models.OpenApiOAuthFlows
    //    {
    //        Implicit = new Microsoft.OpenApi.Models.OpenApiOAuthFlow
    //        {
    //            Scopes = new Dictionary<string, string>
    //            {
    //                { "openid", "Open id" }
    //            },
    //            AuthorizationUrl = new Uri(builder.Configuration["Authentication:Domain"] + "authorize?audience=" + builder.Configuration["Authentication:Audience"])
    //        }
    //    }
    //});
});

builder.Services.AddMvc();

//Add authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["Auth0:Domain"];
    options.Audience = builder.Configuration["Auth0:Audience"];
});

// Make all controllers have authorize attribute
//builder.Services.AddControllers(options =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//    options.Filters.Add(new AuthorizeFilter(policy));
//});

// ConenctionString to database
builder.Services.AddDbContext<RevConnectContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
        //c.OAuthClientId(builder.Configuration["Authentication:ClientId"]);
    });
}

app.UseHttpsRedirection();
app.UseRouting();

// Add authentication and authorization - authenticate first then authorize
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
