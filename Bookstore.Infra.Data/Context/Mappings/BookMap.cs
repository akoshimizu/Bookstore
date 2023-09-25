using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Infra.Data.Context.Mappings
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);
            
            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.Price)
            .IsRequired()
                .HasColumnName("Price")
                .HasColumnType("DECIMAL")
                .HasPrecision(18,2)
                .HasMaxLength(80);

            builder.HasData(
                new Book(1,"Dom Quixote", "O maior romance da Literatura Espanhola é um clássico satírico de alta qualidade crítica.", 29.90m),
                new Book(2,"O Senhor dos Anéis", " Um dos principais clássicos de fantasia do mundo.", 49.90m),
                new Book(3,"O Pequeno Príncipe", " Um dos maiores clássicos infantis foi escrito e ilustrado pelo autor Antoine de Saint-Exupéry quando se encontrava exilado na América do Norte durante a II Guerra Mundial.", 19.90m),
                new Book(4,"Harry Potter e a Pedra Filosofal", "Em Harry Potter e a Pedra Filosofal é apresentado Harry e todo o mundo fantástico a que ele pertence, assim como os perigos pelos quais o garoto está sujeito.", 39.90m)

            );
        }
    }
}