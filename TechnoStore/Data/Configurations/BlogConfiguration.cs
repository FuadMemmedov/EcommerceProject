using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
	public void Configure(EntityTypeBuilder<Blog> builder)
	{
		builder.Property(x => x.Title).IsRequired();
		builder.Property(x => x.Description).IsRequired();
		builder.Property(x => x.ImageUrl).IsRequired();
		builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow.AddHours(4));
	}
}
