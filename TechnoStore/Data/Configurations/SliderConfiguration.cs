using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations;

public class SliderConfiguration : IEntityTypeConfiguration<Slider>
{
	public void Configure(EntityTypeBuilder<Slider> builder)
	{
		builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
		builder.Property(x => x.Price).IsRequired();
		builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow.AddHours(4));
		
	}
}
