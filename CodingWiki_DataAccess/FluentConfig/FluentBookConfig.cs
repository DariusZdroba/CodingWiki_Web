﻿using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            modelBuilder.HasKey(u => u.IDBook);
            modelBuilder.Property(u => u.ISBN).IsRequired().HasMaxLength(50);
            modelBuilder.Ignore(u => u.PriceRange);
            modelBuilder.HasOne(u => u.Publisher).WithMany(z => z.Books).HasForeignKey(u => u.Publisher_Id);
        }
    }
}
 