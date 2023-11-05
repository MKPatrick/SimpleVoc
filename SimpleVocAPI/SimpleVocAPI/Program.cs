using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SimpleVoc.Domain.Shared.Kernel;
using SimpleVoc.Infrastructure.Data;
using SimpleVoc.Infrastructure.Repositories;
using SimpleVocAPI.DTO.Vocabulary;
using SimpleVocAPI.Mapping;
using SimpleVocAPI.Services;
using SimpleVocAPI.Validators.Vocabulary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new VocabularyMapping());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddTransient<IVocabularyService, VocabularyService>();
builder.Services.AddTransient<IVocabularyRepository, VocabularyRepository>();


//Validators
builder.Services.AddScoped<IValidator<UpdateVocabularyRequest>, UpdateVocabularyValidation>();
builder.Services.AddScoped<IValidator<AddVocabularyRequest>, AddVocabularyValidation>();


builder.Services.AddFluentValidationAutoValidation();


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
