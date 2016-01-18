using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBox.Model.Models;

namespace FileBox.Data.Configuration
{
    public class FilesInfoConfiguration: EntityTypeConfiguration<FilesInfo>
    {
        public FilesInfoConfiguration()
        {
            ToTable("FilesInfo");
            HasKey(f => f.FilesInfoID);
            Property(f => f.FilesInfoID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(f => f.Extension).HasMaxLength(6);
            Property(f => f.FileName).IsRequired();
        }
    }
}
