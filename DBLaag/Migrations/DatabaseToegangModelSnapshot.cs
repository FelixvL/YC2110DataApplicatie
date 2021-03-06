// <auto-generated />
using System;
using DBLaag;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBLaag.Migrations
{
    [DbContext(typeof(DatabaseToegang))]
    partial class DatabaseToegangModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DBLaag.BesteldeProducten", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BestellingId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("aantalVanHetProduct")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BestellingId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("besteldeProducten");
                });

            modelBuilder.Entity("DBLaag.Bestelling", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<string>("KlantNaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("bestellingen");
                });

            modelBuilder.Entity("DBLaag.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("Fotonaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prijs")
                        .HasColumnType("float");

                    b.Property<string>("Specificaties")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("producten");
                });

            modelBuilder.Entity("DBLaag.BesteldeProducten", b =>
                {
                    b.HasOne("DBLaag.Bestelling", null)
                        .WithMany("BesteldeProducten")
                        .HasForeignKey("BestellingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBLaag.Product", "Product")
                        .WithOne("BesteldeProduct")
                        .HasForeignKey("DBLaag.BesteldeProducten", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DBLaag.Bestelling", b =>
                {
                    b.Navigation("BesteldeProducten");
                });

            modelBuilder.Entity("DBLaag.Product", b =>
                {
                    b.Navigation("BesteldeProduct");
                });
#pragma warning restore 612, 618
        }
    }
}
