using Microsoft.EntityFrameworkCore;
using WalletAppBackend.DatabaseProvider;
using WalletAppBackend.Services.Interfaces;
using WalletAppBackend.Services.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IPointsService, PointsService>();
builder.Services.AddDbContext<DataContext>(context => context.UseNpgsql(builder.Configuration.GetConnectionString("MainDb")), ServiceLifetime.Scoped);
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
