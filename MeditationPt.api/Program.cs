using MeditationPt.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MeditationsDatabaseSettings>(builder.Configuration.GetSection("MeditationsDatabase"));
builder.Services.AddSingleton<MeditationsService>();

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