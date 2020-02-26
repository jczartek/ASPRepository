using Model.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Model.Configurations
{
    class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Name)
                .HasMaxLength(50);
        }
    }
}
