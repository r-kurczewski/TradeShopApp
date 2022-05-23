﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradeShopApp.Data;

namespace TradeShopApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220520130135_MessagesTransactions")]
    partial class MessagesTransactions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TradeShopApp.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TradeShopApp.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Clothes"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Shirts",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Hoodies",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Electronics"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Mobile Phones",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Computers",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "TVs",
                            ParentCategoryId = 4
                        },
                        new
                        {
                            CategoryId = 8,
                            CategoryName = "Books"
                        },
                        new
                        {
                            CategoryId = 9,
                            CategoryName = "Romance",
                            ParentCategoryId = 8
                        },
                        new
                        {
                            CategoryId = 10,
                            CategoryName = "Fantasy",
                            ParentCategoryId = 8
                        },
                        new
                        {
                            CategoryId = 11,
                            CategoryName = "Sci-Fi",
                            ParentCategoryId = 8
                        },
                        new
                        {
                            CategoryId = 12,
                            CategoryName = "Smartphones",
                            ParentCategoryId = 5
                        });
                });

            modelBuilder.Entity("TradeShopApp.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ToSeller")
                        .HasColumnType("bit");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("TradeShopApp.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OfferDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortDescription")
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<string>("ThumbnailPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 12,
                            LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin varius lacus eu feugiat faucibus. Proin eu auctor ipsum. Maecenas ultricies eu eros nec euismod. Proin vel neque sagittis leo convallis scelerisque. Nulla scelerisque purus eu rhoncus bibendum. Praesent tempor at purus id vulputate. Donec a placerat augue. Suspendisse mollis lacinia dictum. Suspendisse iaculis diam eu lacus hendrerit eleifend. Nullam nunc risus, pharetra sed nulla in, consequat efficitur nunc. In hac habitasse platea dictumst. Vivamus vitae ante ullamcorper, accumsan urna feugiat, posuere libero. Pellentesque est ex, dignissim vitae mauris in, cursus blandit velit. Maecenas ut mi venenatis, laoreet tortor rhoncus, vestibulum enim. Donec sit amet nisl nec nulla maximus tristique. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Pellentesque volutpat vestibulum lorem id rhoncus. Cras ultrices lorem vel nunc consequat, ac ultrices nisi fermentum. Donec ullamcorper lorem aliquam enim ullamcorper tristique. Mauris convallis arcu ut dui faucibus, sed sollicitudin metus feugiat. Nulla eget iaculis velit. Nulla porta accumsan nisl, id porttitor libero accumsan ut. Nam vestibulum velit eu leo cursus, a bibendum tortor volutpat. Praesent blandit elementum neque, eu ornare lectus placerat et. Aliquam scelerisque, libero et congue maximus, diam nulla viverra quam, tristique lobortis neque tortor a justo. Curabitur vitae purus quis ante hendrerit hendrerit. Sed nec dolor magna. Ut rhoncus ultrices justo sit amet malesuada. Vestibulum augue mauris, porta in ullamcorper aliquet, aliquam nec metus. Curabitur non risus ut felis condimentum venenatis sit amet vel quam.",
                            OfferDetails = "Shipping only to the USA and EU.\r\nStandard Delivery (3-7 days): $10.50\r\nExpress Delivery: (1-3 days) $15.90",
                            Price = 849.99m,
                            ProductName = "EyePhone 5",
                            Quantity = 2L,
                            ShortDescription = "Great EyePhone 5 with etui, two colors available: red and white.",
                            ThumbnailPath = "https://upload.wikimedia.org/wikipedia/commons/c/c7/Two_iPhones_%281091302%29.jpg"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 10,
                            LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin varius lacus eu feugiat faucibus. Proin eu auctor ipsum. Maecenas ultricies eu eros nec euismod. Proin vel neque sagittis leo convallis scelerisque. Nulla scelerisque purus eu rhoncus bibendum. Praesent tempor at purus id vulputate. Donec a placerat augue. Suspendisse mollis lacinia dictum. Suspendisse iaculis diam eu lacus hendrerit eleifend. Nullam nunc risus, pharetra sed nulla in, consequat efficitur nunc. In hac habitasse platea dictumst. Vivamus vitae ante ullamcorper, accumsan urna feugiat, posuere libero. Pellentesque est ex, dignissim vitae mauris in, cursus blandit velit. Maecenas ut mi venenatis, laoreet tortor rhoncus, vestibulum enim. Donec sit amet nisl nec nulla maximus tristique. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Pellentesque volutpat vestibulum lorem id rhoncus. Cras ultrices lorem vel nunc consequat, ac ultrices nisi fermentum. Donec ullamcorper lorem aliquam enim ullamcorper tristique. Mauris convallis arcu ut dui faucibus, sed sollicitudin metus feugiat. Nulla eget iaculis velit. Nulla porta accumsan nisl, id porttitor libero accumsan ut. Nam vestibulum velit eu leo cursus, a bibendum tortor volutpat. Praesent blandit elementum neque, eu ornare lectus placerat et. Aliquam scelerisque, libero et congue maximus, diam nulla viverra quam, tristique lobortis neque tortor a justo. Curabitur vitae purus quis ante hendrerit hendrerit. Sed nec dolor magna. Ut rhoncus ultrices justo sit amet malesuada. Vestibulum augue mauris, porta in ullamcorper aliquet, aliquam nec metus. Curabitur non risus ut felis condimentum venenatis sit amet vel quam.",
                            OfferDetails = "Shipping only to the USA and EU.\r\nStandard Delivery (3-7 days): $10.50\r\nExpress Delivery: (1-3 days) $15.90",
                            Price = 35.60m,
                            ProductName = "Whicher: The lady of the River",
                            Quantity = 1L,
                            ShortDescription = "Great book based on even better game.",
                            ThumbnailPath = "https://data.europa.eu/sites/default/files/news/2020-08-06-edp_book_club.png"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin varius lacus eu feugiat faucibus. Proin eu auctor ipsum. Maecenas ultricies eu eros nec euismod. Proin vel neque sagittis leo convallis scelerisque. Nulla scelerisque purus eu rhoncus bibendum. Praesent tempor at purus id vulputate. Donec a placerat augue. Suspendisse mollis lacinia dictum. Suspendisse iaculis diam eu lacus hendrerit eleifend. Nullam nunc risus, pharetra sed nulla in, consequat efficitur nunc. In hac habitasse platea dictumst. Vivamus vitae ante ullamcorper, accumsan urna feugiat, posuere libero. Pellentesque est ex, dignissim vitae mauris in, cursus blandit velit. Maecenas ut mi venenatis, laoreet tortor rhoncus, vestibulum enim. Donec sit amet nisl nec nulla maximus tristique. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Pellentesque volutpat vestibulum lorem id rhoncus. Cras ultrices lorem vel nunc consequat, ac ultrices nisi fermentum. Donec ullamcorper lorem aliquam enim ullamcorper tristique. Mauris convallis arcu ut dui faucibus, sed sollicitudin metus feugiat. Nulla eget iaculis velit. Nulla porta accumsan nisl, id porttitor libero accumsan ut. Nam vestibulum velit eu leo cursus, a bibendum tortor volutpat. Praesent blandit elementum neque, eu ornare lectus placerat et. Aliquam scelerisque, libero et congue maximus, diam nulla viverra quam, tristique lobortis neque tortor a justo. Curabitur vitae purus quis ante hendrerit hendrerit. Sed nec dolor magna. Ut rhoncus ultrices justo sit amet malesuada. Vestibulum augue mauris, porta in ullamcorper aliquet, aliquam nec metus. Curabitur non risus ut felis condimentum venenatis sit amet vel quam.",
                            OfferDetails = "Shipping only to the USA and EU.\r\nStandard Delivery (3-7 days): $10.50\r\nExpress Delivery: (1-3 days) $15.90",
                            Price = 15.60m,
                            ProductName = "Black hoodie",
                            Quantity = 15L,
                            ShortDescription = "Very stylish black hoodie.",
                            ThumbnailPath = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTb3I_38rtMgpNTapQ30tzsPJR03Oex6im7hg&usqp=CAU"
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 7,
                            LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin varius lacus eu feugiat faucibus. Proin eu auctor ipsum. Maecenas ultricies eu eros nec euismod. Proin vel neque sagittis leo convallis scelerisque. Nulla scelerisque purus eu rhoncus bibendum. Praesent tempor at purus id vulputate. Donec a placerat augue. Suspendisse mollis lacinia dictum. Suspendisse iaculis diam eu lacus hendrerit eleifend. Nullam nunc risus, pharetra sed nulla in, consequat efficitur nunc. In hac habitasse platea dictumst. Vivamus vitae ante ullamcorper, accumsan urna feugiat, posuere libero. Pellentesque est ex, dignissim vitae mauris in, cursus blandit velit. Maecenas ut mi venenatis, laoreet tortor rhoncus, vestibulum enim. Donec sit amet nisl nec nulla maximus tristique. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Pellentesque volutpat vestibulum lorem id rhoncus. Cras ultrices lorem vel nunc consequat, ac ultrices nisi fermentum. Donec ullamcorper lorem aliquam enim ullamcorper tristique. Mauris convallis arcu ut dui faucibus, sed sollicitudin metus feugiat. Nulla eget iaculis velit. Nulla porta accumsan nisl, id porttitor libero accumsan ut. Nam vestibulum velit eu leo cursus, a bibendum tortor volutpat. Praesent blandit elementum neque, eu ornare lectus placerat et. Aliquam scelerisque, libero et congue maximus, diam nulla viverra quam, tristique lobortis neque tortor a justo. Curabitur vitae purus quis ante hendrerit hendrerit. Sed nec dolor magna. Ut rhoncus ultrices justo sit amet malesuada. Vestibulum augue mauris, porta in ullamcorper aliquet, aliquam nec metus. Curabitur non risus ut felis condimentum venenatis sit amet vel quam.",
                            OfferDetails = "Shipping only to the USA and EU.\r\nStandard Delivery (3-7 days): $10.50\r\nExpress Delivery: (1-3 days) $15.90",
                            Price = 1629.99m,
                            ProductName = "TV FG",
                            Quantity = 1L,
                            ShortDescription = "Manufacturer: FG\r\nScreen diagonal: 32 inches(80 cm)\r\nNominal resolution: 1366 x 768(HD Ready) pixels\r\nImplementation technology: LCD - LED",
                            ThumbnailPath = "https://www.publicdomainpictures.net/pictures/70000/velka/tv-isolated-background-clipart.jpg"
                        });
                });

            modelBuilder.Entity("TradeShopApp.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BuyerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TradeShopApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TradeShopApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TradeShopApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TradeShopApp.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TradeShopApp.Models.Category", b =>
                {
                    b.HasOne("TradeShopApp.Models.Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("TradeShopApp.Models.Message", b =>
                {
                    b.HasOne("TradeShopApp.Models.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("TradeShopApp.Models.Product", b =>
                {
                    b.HasOne("TradeShopApp.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TradeShopApp.Models.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Category");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TradeShopApp.Models.Transaction", b =>
                {
                    b.HasOne("TradeShopApp.Models.ApplicationUser", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId");

                    b.HasOne("TradeShopApp.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Buyer");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}