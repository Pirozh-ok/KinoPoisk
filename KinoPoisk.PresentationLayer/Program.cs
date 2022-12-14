using KinoPoisk.DomainLayer.Intarfaces;
using KinoPoisk.PresentationLayer.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions
                .ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddIdentitySettings();
builder.Services.AddUserServices();
builder.Services.AddAutoMapper();
builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "policy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("policy"); 

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
