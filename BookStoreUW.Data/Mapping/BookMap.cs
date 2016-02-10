using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BookStoreUW.Core.Data;

namespace BookStoreUW.Data.Mapping
{
    public class BookMap:EntityTypeConfiguration<Book>
    {

        public BookMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Title).IsRequired();
            Property(t => t.Author).IsRequired();
            Property(t => t.ISBN).IsRequired();
            Property(t => t.Published).IsRequired();
            ToTable("Books");
        }
    }
}
