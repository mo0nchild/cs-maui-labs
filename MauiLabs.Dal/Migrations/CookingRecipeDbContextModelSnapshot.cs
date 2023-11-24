﻿// <auto-generated />
using System;
using MauiLabs.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MauiLabs.Dal.Migrations
{
    [DbContext(typeof(CookingRecipeDbContext))]
    partial class CookingRecipeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MauiLabs.Dal.Entities.Authorization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("UserProfileId")
                        .IsUnique();

                    b.ToTable("Authorization", "public");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.Bookmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ProfileId")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProfileId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Bookmark", "public");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProfileId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PublicationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Rating")
                        .HasColumnType("double precision");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ProfileId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Comment", "public", t =>
                        {
                            t.HasCheckConstraint("Rating_Constraint", "\"Rating\" BETWEEN 0 AND 5");
                        });
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.CookingRecipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("PublicationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PublisherId")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeCategoryId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("PublisherId");

                    b.HasIndex("RecipeCategoryId");

                    b.ToTable("CookingRecipe", "public");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.FriendList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddresseeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RequesterId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AddresseeId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("RequesterId");

                    b.ToTable("FriendList", "public");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.IngredientUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.ToTable("IngredientUnit", "public");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.IngredientsList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CookingRecipeId")
                        .HasColumnType("integer");

                    b.Property<int>("IngredientUnitId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CookingRecipeId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("IngredientUnitId");

                    b.ToTable("IngredientsList", "public");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.LoggingInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MethodName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("UserInfo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("LoggingInfo");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.RecipeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("RecipeCategory", "public");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.Recommendation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FromUserId")
                        .HasColumnType("integer");

                    b.Property<int>("RecipeId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("ToUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("RecipeId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Recommendation", "public");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ReferenceLink")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("UserProfile", "public");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.Authorization", b =>
                {
                    b.HasOne("MauiLabs.Dal.Entities.UserProfile", "UserProfile")
                        .WithOne("Authorization")
                        .HasForeignKey("MauiLabs.Dal.Entities.Authorization", "UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.Bookmark", b =>
                {
                    b.HasOne("MauiLabs.Dal.Entities.UserProfile", "Profile")
                        .WithMany("Bookmarks")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MauiLabs.Dal.Entities.CookingRecipe", "Recipe")
                        .WithMany("Bookmarks")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.Comment", b =>
                {
                    b.HasOne("MauiLabs.Dal.Entities.UserProfile", "Profile")
                        .WithMany("Comments")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MauiLabs.Dal.Entities.CookingRecipe", "Recipe")
                        .WithMany("Comments")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.CookingRecipe", b =>
                {
                    b.HasOne("MauiLabs.Dal.Entities.UserProfile", "Publisher")
                        .WithMany("Recipes")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MauiLabs.Dal.Entities.RecipeCategory", "RecipeCategory")
                        .WithMany("Recipes")
                        .HasForeignKey("RecipeCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");

                    b.Navigation("RecipeCategory");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.FriendList", b =>
                {
                    b.HasOne("MauiLabs.Dal.Entities.UserProfile", "Addressee")
                        .WithMany()
                        .HasForeignKey("AddresseeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MauiLabs.Dal.Entities.UserProfile", "Requester")
                        .WithMany()
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Addressee");

                    b.Navigation("Requester");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.IngredientsList", b =>
                {
                    b.HasOne("MauiLabs.Dal.Entities.CookingRecipe", "CookingRecipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("CookingRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MauiLabs.Dal.Entities.IngredientUnit", "IngredientUnit")
                        .WithMany("IngredientsLists")
                        .HasForeignKey("IngredientUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CookingRecipe");

                    b.Navigation("IngredientUnit");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.Recommendation", b =>
                {
                    b.HasOne("MauiLabs.Dal.Entities.UserProfile", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MauiLabs.Dal.Entities.CookingRecipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MauiLabs.Dal.Entities.UserProfile", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("Recipe");

                    b.Navigation("ToUser");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.CookingRecipe", b =>
                {
                    b.Navigation("Bookmarks");

                    b.Navigation("Comments");

                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.IngredientUnit", b =>
                {
                    b.Navigation("IngredientsLists");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.RecipeCategory", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("MauiLabs.Dal.Entities.UserProfile", b =>
                {
                    b.Navigation("Authorization")
                        .IsRequired();

                    b.Navigation("Bookmarks");

                    b.Navigation("Comments");

                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
