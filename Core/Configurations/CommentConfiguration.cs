using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.IdentityModel.Protocols;

namespace Core.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.CommentId);
            builder.Property(u => u.CommentId)
                   .ValueGeneratedOnAdd();
            builder.HasOne(c => c.User).WithMany(c => c.Comments).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p=>p.Product).WithMany(p => p.Comments).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
