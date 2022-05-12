using Alphasteller.VehicleApplication.Business.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Business taraf�nda yazm�� oldu�um DependenciesExtension class�ndaki AddDependencies metodunu IServiceCollectiona extend ettim. Bu yazd���m metot sayesinde hem ba��ml�l�klar�m� startup(art�k program.cs) dosyas�n�n i�ine yazarak kodu �i�irmedim. Hem de Katmanl� mimari gere�i Sunum katman�n�n direkt olarak DataAccess katman�na eri�imini engelledim. 
//
builder.Services.AddDependencies();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
