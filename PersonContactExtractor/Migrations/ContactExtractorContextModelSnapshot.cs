﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonContactExtractor.Persistance;

#nullable disable

namespace PersonContactExtractor.Migrations
{
    [DbContext(typeof(ContactExtractorContext))]
    partial class ContactExtractorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("PersonContactExtractor.Persistance.DocumentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDateTimeUtc")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DocumentResultId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginFileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PlainTextFilePath")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Processed")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SizeInBytes")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DocumentResultId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("PersonContactExtractor.Persistance.DocumentResultEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDateTimeUtc")
                        .HasColumnType("TEXT");

                    b.Property<int>("DocumentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResultId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DocumentResultEntity");
                });

            modelBuilder.Entity("PersonContactExtractor.Persistance.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDateTimeUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subdivision")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("PersonContactExtractor.Persistance.PersonContacts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDateTimeUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ResultEntityId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("ResultEntityId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PersonContactExtractor.Persistance.ResultEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDateTimeUtc")
                        .HasColumnType("TEXT");

                    b.Property<int>("DocumentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("PersonContactExtractor.Persistance.DocumentEntity", b =>
                {
                    b.HasOne("PersonContactExtractor.Persistance.DocumentResultEntity", "DocumentResult")
                        .WithMany()
                        .HasForeignKey("DocumentResultId");

                    b.Navigation("DocumentResult");
                });

            modelBuilder.Entity("PersonContactExtractor.Persistance.PersonContacts", b =>
                {
                    b.HasOne("PersonContactExtractor.Persistance.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonContactExtractor.Persistance.ResultEntity", "ResultEntity")
                        .WithMany("Persons")
                        .HasForeignKey("ResultEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("ResultEntity");
                });

            modelBuilder.Entity("PersonContactExtractor.Persistance.ResultEntity", b =>
                {
                    b.HasOne("PersonContactExtractor.Persistance.DocumentEntity", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("PersonContactExtractor.Persistance.ResultEntity", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
