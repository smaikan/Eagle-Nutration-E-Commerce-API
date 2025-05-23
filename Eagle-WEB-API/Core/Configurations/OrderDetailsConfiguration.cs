using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Core.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => od.OrderDetailId);
            builder.Property(u => u.OrderDetailId)
                   .ValueGeneratedOnAdd();

            builder.Property(od => od.Quantity)
                   .IsRequired();

            builder.Property(od => od.UnitPrice)
                   .IsRequired();

            // OrderDetail → Order (N → 1)
            builder.HasOne(od => od.Order)
                   .WithMany(o => o.OrderDetails)
                   .HasForeignKey(od => od.OrderId);

            // OrderDetail → Product (N → 1)
            builder.HasOne(od => od.Product)
                   .WithMany() // ters ilişki kurulmayacak
                   .HasForeignKey(od => od.ProductId);
        }
    }
}
