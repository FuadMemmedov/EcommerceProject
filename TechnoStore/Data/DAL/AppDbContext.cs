﻿using Core.Models;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL;

public class AppDbContext : DbContext
{
	public DbSet<Slider> Sliders { get; set; }
	public DbSet<ShopSlider> ShopSliders { get; set; }
	public AppDbContext(DbContextOptions options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(SliderConfiguration).Assembly);
		base.OnModelCreating(modelBuilder);
	}
}
