using RevConnectChat.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
//builder.Services.AddSignalR().AddAzureSignalR();
builder.Services.AddCors(Options => {
    Options.AddPolicy("AllowAll",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")    //AllowAnyOrigin()
                   .WithOrigins("https://revconnect5.azurewebsites.net")
                   .WithOrigins("https://revconnectapp.azurewebsites.net")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
});
// builder.Services.AddCors(options =>
// {
// options.AddPolicy(name: "_myAllowSpecificOrigins",
//   policy  =>
//   {
//   policy.WithOrigins("http://localhost:4200",
//   "http://www.contoso.com");
//   });
// });
var app = builder.Build();
app.UseAuthorization();
app.UseCors("AllowAll");
//app.UseCors("_myAllowSpecificOrigins");
app.MapGet("/", () => "Hello World!");

app.MapHub<ChatHub>("/chat");
app.Run();