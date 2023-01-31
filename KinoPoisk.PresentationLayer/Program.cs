using KinoPoisk.DomainLayer.Settings;
using KinoPoisk.PresentationLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddIdentitySettings();
builder.Services.AddUserServices();
builder.Services.AddAutoMapper();
builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddSwaggerOptions();
builder.Services.AddCors();
builder.Services.AddOptions(); 

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtBearerSettings"));
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
