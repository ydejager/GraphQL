﻿// <auto-generated />
using System;
using EfGraphQl.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfGraphQl.Migrations
{
    [DbContext(typeof(TaskContext))]
    [Migration("20181105203016_AddTasks")]
    partial class AddTasks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfGraphQl.Data.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new { Id = new Guid("35d3904b-6715-4ab5-ba41-73271e584bd6") },
                        new { Id = new Guid("73482990-5eb5-42ea-b7dd-e600d2019db7") },
                        new { Id = new Guid("70e765d2-1356-444c-a1aa-9195df7a8aed") },
                        new { Id = new Guid("6fee5a1b-1e9c-4d9b-9433-fec84ee41037") },
                        new { Id = new Guid("7c016b7f-baae-49c7-b55a-acc9e74cfd56") },
                        new { Id = new Guid("d9227513-1f13-4110-a583-de7eca5782a7") },
                        new { Id = new Guid("12d5e479-709d-4662-895a-4950bc48c29b") },
                        new { Id = new Guid("0fdccd70-e341-459a-8279-30db9c8d7b63") },
                        new { Id = new Guid("d6f5da4e-aac4-4ad4-8ba5-b0343d805472") },
                        new { Id = new Guid("bee24e9c-f7c2-41a3-ab86-d2e7986110e1") },
                        new { Id = new Guid("3a815a13-b3ef-4bed-b806-770bf5100ad2") },
                        new { Id = new Guid("6322df36-4643-471d-82bf-8980900ba20f") },
                        new { Id = new Guid("3fe3574a-2d70-4af0-af65-a4570d4d9404") }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}