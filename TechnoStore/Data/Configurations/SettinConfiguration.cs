using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations;

public class SettinConfiguration : IEntityTypeConfiguration<Setting>
{
	public void Configure(EntityTypeBuilder<Setting> builder)
	{
		builder.Property(x => x.Key).IsRequired();
		builder.Property(x => x.Value).IsRequired();
		builder.Property(x => x.CreatedDate).HasDefaultValue(DateTime.UtcNow.AddHours(4));
	}
}
