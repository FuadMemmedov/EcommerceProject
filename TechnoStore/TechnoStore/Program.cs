using FluentValidation.AspNetCore;
using Business.Mapping;
using Data.DAL;
using Microsoft.EntityFrameworkCore;
using Business.Service.Abstracts;
using Business.Service.Concretes;
using Core.RepositoryAbstracts;
using Data.RepositoryConcretes;
using Business.DTOs.SliderDTOs;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using TechnoStore.ViewService;


namespace TechnoStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.ReferenceHandler =
                System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            }). AddRazorRuntimeCompilation().AddFluentValidation(x =>
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


			builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedAccount = true;
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequiredLength = 8;

                opt.User.RequireUniqueEmail = false;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
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

            builder.Services.AddScoped<IProductColorRepository, ProductColorRepository>();
            builder.Services.AddScoped<IProductColorService, ProductColorService>();

            builder.Services.AddScoped<IBrandRepository, BrandRepository>();
            builder.Services.AddScoped<IBrandService, BrandService>();

            builder.Services.AddScoped<ITeamRepository, TeamRepository>();
            builder.Services.AddScoped<ITeamService, TeamService>();

			builder.Services.AddScoped<IContactPostRepository, ContactPostRepository>();
			builder.Services.AddScoped<IContactPostService, ContactPostService>();

			builder.Services.AddScoped<IBlogRepository, BlogRepository>();
			builder.Services.AddScoped<IBlogService, BlogService>();


            builder.Services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            builder.Services.AddScoped<IBasketItemService, BasketItemService>();


            builder.Services.AddScoped<ITagRepository, TagRepository>();
            builder.Services.AddScoped<ITagService, TagService>();

            builder.Services.AddScoped<IBlogTagRepository, BlogTagRepository>();

			builder.Services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
			builder.Services.AddScoped<IBlogCategoryService, BlogCategoryService>();

			builder.Services.AddScoped<ISettingRepository, SettingRepository>();
			builder.Services.AddScoped<SettingService>();

			builder.Services.AddScoped<LayoutService>();



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
