﻿using Core.Models;
using Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL;

public class AppDbContext : IdentityDbContext
{
	public DbSet<Slider> Sliders { get; set; }
	public DbSet<ShopSlider> ShopSliders { get; set; }
	public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
	public DbSet<ProductImage> ProductImages { get; set; }
	public DbSet<ProductColor> Colors { get; set; }
	public DbSet<Brand> Brands { get; set; }
	public DbSet<Setting> Settings { get; set; }
	public DbSet<AppUser> AppUsers { get; set; }
	public DbSet<Team> Teams { get; set; }
	public DbSet<ContactPost> ContactPosts { get; set; }
	public DbSet<Blog> Blogs { get; set; }
	public DbSet<Comment> Comments { get; set; }
    public AppDbContext(DbContextOptions options) : base(options) {}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(SliderConfiguration).Assembly);
		base.OnModelCreating(modelBuilder);
	}
}
