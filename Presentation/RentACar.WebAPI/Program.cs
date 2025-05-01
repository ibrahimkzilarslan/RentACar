using RentACar.Application.Features.RepositoryPattern;
using RentACar.Application.Interfaces.BlogInterfaces;
using RentACar.Application.Interfaces.CarInterfaces;
using RentACar.Application.Interfaces.CarPricingInterfaces;
using RentACar.Application.Interfaces.TagCloudInterfaces;
using RentACar.Application.Interfaces;
using RentACar.Persistence.Context;
using RentACar.Persistence.Repositories.BlogRepositories;
using RentACar.Persistence.Repositories.CarPricingRepositories;
using RentACar.Persistence.Repositories.CarRepositories;
using RentACar.Persistence.Repositories.CommentRepositories;
using RentACar.Persistence.Repositories.TagCloudRepositories;
using RentACar.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACar.Application.Features.CQRS.Handlers.BannerHandlers;
using RentACar.Application.Features.CQRS.Handlers.BrandHandlers;
using RentACar.Application.Features.CQRS.Handlers.CarHandlers;
using RentACar.Application.Features.CQRS.Handlers.CategoryHandlers;
using RentACar.Application.Features.CQRS.Handlers.ContactHandlers;
using RentACar.Application.Services;
using RentACar.Application.Interfaces.StatisticsInterfaces;
using RentACar.Persistence.Repositories.StatisticsRepositories;

var builder = WebApplication.CreateBuilder(args);

// Context ve Repository S�n�flar�
builder.Services.AddScoped<RentACarContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticsRepository));



// About S�n�f� Konfig�rasyonu
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

// Banner S�n�f� Konfig�rasyonu
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();


// Brand S�n�f� Konfig�rasyonu
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();

// Car S�n�f� Konfig�rasyonu
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();


// Category S�n�f� Konfig�rasyonu
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();


// Contact S�n�f� Konfig�rasyonu
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();

// Mediator registiration

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddDbContext<RentACarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
