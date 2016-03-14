using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TodoCore.Data;

namespace _2dooCore.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20160314140655_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("TodoCore.Models.TodoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Done");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.Property<Guid>("TodoListId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TodoCore.Models.TodoList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 40);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TodoCore.Models.TodoItem", b =>
                {
                    b.HasOne("TodoCore.Models.TodoList")
                        .WithMany()
                        .HasForeignKey("TodoListId");
                });
        }
    }
}
