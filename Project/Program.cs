using Project.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
builder.WebHost.ConfigureKestrel(op =>
{
    op.ListenAnyIP(4080, listen =>
    {
        listen.UseHttps();
        listen.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1AndHttp2;
    });
});
builder.Services.AddServiceBuilderExtensions(builder.Configuration);
//Application builder 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseApplicationBuilderExtensions();
app.MapControllers();
app.Run();
