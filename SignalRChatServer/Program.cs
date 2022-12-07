using SignalRChatServer.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy
.AllowCredentials()
.AllowAnyHeader()
.AllowAnyMethod()
.SetIsOriginAllowed(x => true)));

builder.Services.AddSignalR();



var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseCors();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chatHub");
});
app.Run();
