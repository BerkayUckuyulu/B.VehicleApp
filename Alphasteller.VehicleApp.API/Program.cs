using Alphasteller.VehicleApplication.Business.DependencyResolvers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Business tarafýnda yazmýþ olduðum DependenciesExtension classýndaki AddDependencies metodunu IServiceCollectiona extend ettim. Bu yazdýðým metot sayesinde hem baðýmlýlýklarýmý startup(artýk program.cs) dosyasýnýn içine yazarak kodu þiþirmedim. Hem de Katmanlý mimari gereði Sunum katmanýnýn direkt olarak DataAccess katmanýna eriþimini engelledim. 
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
