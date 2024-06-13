using FluentValidation.AspNetCore;
using Business.Mapping;
using Data.DAL;
using Microsoft.EntityFrameworkCore;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Core.RepositoryAbstracts;
using Data.RepositoryConcretes;
using Business.DTOs.SliderDTOs;

namespace TechnoStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddFluentValidation(x =>
			{
				x.RegisterValidatorsFromAssemblyContaining(typeof(SliderCreateDTOValidator));
				x.RegisterValidatorsFromAssemblyContaining(typeof(SliderUpdateDTOValidator));
                x.RegisterValidatorsFromAssemblyContaining(typeof(ShopSliderCreateDTOValidator));
                x.RegisterValidatorsFromAssemblyContaining(typeof(ShopSliderUpdateDTOValidator));
            });

			builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
			builder.Services.AddDbContext<AppDbContext>(opt =>


            opt.UseSqlServer(builder.Configuration.GetConnectionString("default"))

            );

			builder.Services.AddScoped<ISliderService, SliderService>();
			builder.Services.AddScoped<ISliderRepository, SliderRepository>();
            builder.Services.AddScoped<IShopSliderService, ShopSliderService>();
            builder.Services.AddScoped<IShopSliderRepository, ShopSliderRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
            builder.Services.AddScoped<IFaqService, FaqService>();
            builder.Services.AddScoped<IFaqRepository, FaqRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
			app.MapControllerRoute(
		   name: "areas",
		   pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}"
		  );

			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
