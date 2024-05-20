using PermissionApi;
using PermissionApi.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<PermissionDbContext>(p => p.UseSqlServer("perrmisionsDB"));
// builder.Services.AddSqlServer<PermissionDbContext>("Server=DESKTOP-R6SKMD4;Database=perrmisionsDB; Trusted_Connection=True");
builder.Services.AddSqlite<PermissionDbContext>("Data Source=permissions.db");
builder.Services.AddSingleton<DataBaseConnect>();
builder.Services.AddScoped<PermissionTypeService>();
builder.Services.AddScoped<PermissionServices>();
builder.Services.AddControllers();


var app = builder.Build();

var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<PermissionDbContext>();
var newConectionDataBase = scope.ServiceProvider.GetRequiredService<DataBaseConnect>();
await newConectionDataBase.Conected(dbContext);

app.MapGet("/", async () => "API is running");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();