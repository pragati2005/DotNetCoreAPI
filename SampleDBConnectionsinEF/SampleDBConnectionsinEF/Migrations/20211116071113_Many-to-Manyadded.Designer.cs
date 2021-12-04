﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleDBConnectionsinEF.Data;

namespace SampleDBConnectionsinEF.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20211116071113_Many-to-Manyadded")]
    partial class ManytoManyadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SampleDBConnectionsinEF.Models.Authors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("author");
                });

            modelBuilder.Entity("SampleDBConnectionsinEF.Models.Book_Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("books_authors");
                });

            modelBuilder.Entity("SampleDBConnectionsinEF.Models.Books", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Coverurl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("genere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("publisherid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("publisherid");

                    b.ToTable("books");
                });

            modelBuilder.Entity("SampleDBConnectionsinEF.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("PublisherName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publishers");
                });

            modelBuilder.Entity("SampleDBConnectionsinEF.Models.Book_Author", b =>
                {
                    b.HasOne("SampleDBConnectionsinEF.Models.Authors", "Author")
                        .WithMany("Book_Authors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SampleDBConnectionsinEF.Models.Books", "book")
                        .WithMany("Book_Authors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("book");
                });

            modelBuilder.Entity("SampleDBConnectionsinEF.Models.Books", b =>
                {
                    b.HasOne("SampleDBConnectionsinEF.Models.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("publisherid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("SampleDBConnectionsinEF.Models.Authors", b =>
                {
                    b.Navigation("Book_Authors");
                });

            modelBuilder.Entity("SampleDBConnectionsinEF.Models.Books", b =>
                {
                    b.Navigation("Book_Authors");
                });
#pragma warning restore 612, 618
        }
    }
}
