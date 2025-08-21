using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Configurations
{
        public class OrderConfiguration : IEntityTypeConfiguration<Order>
        {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);
            builder.Property(u => u.OrderId)
                   .ValueGeneratedOnAdd();

            builder.Property(o => o.TotalPrice).IsRequired();
            builder.Property(o => o.OrderDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(o => o.OrderStatus).HasDefaultValue("Sipariş Alındı");

            builder.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);
          
        }
        }
    }
    
