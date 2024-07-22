using Apexa.Data;
using Apexa.Repositories;
using Apexa.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<AdvisorContext>(options =>
  //  options.UseInMemoryDatabase("AdvisorsDB"));
builder.Services.AddScoped<IAdvisorRepository, AdvisorRepository>();
builder.Services.AddScoped<IAdvisorService, AdvisorService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();