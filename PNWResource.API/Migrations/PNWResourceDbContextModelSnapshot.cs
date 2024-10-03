﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PNWResource.API.Data;

#nullable disable

namespace PNWResource.API.Migrations
{
    [DbContext(typeof(PNWResourceDbContext))]
    partial class PNWResourceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PNWResource.API.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Portland",
                            State = "OR"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Salem",
                            State = "OR"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Vancouver",
                            State = "WA"
                        });
                });

            modelBuilder.Entity("PNWResource.API.Entities.DaycareCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("DaycareCenters");
                });

            modelBuilder.Entity("PNWResource.API.Entities.DaycareCenterEvent", b =>
                {
                    b.Property<int>("DaycareCenterId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("DaycareCenterId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("DaycareCenterEvent");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TimeEnds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TimeStarts")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<bool?>("HasChildrenSection")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("PNWResource.API.Entities.LibraryEvent", b =>
                {
                    b.Property<int>("LibraryId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("LibraryId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("LibraryEvent");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Park", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<bool?>("HasPicnicArea")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasPlayground")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaygroundId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("PlaygroundId")
                        .IsUnique()
                        .HasFilter("[PlaygroundId] IS NOT NULL");

                    b.ToTable("Parks");
                });

            modelBuilder.Entity("PNWResource.API.Entities.ParkEvent", b =>
                {
                    b.Property<int>("ParkId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("ParkId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("ParkEvent");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Playground", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateConstructed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("HasBathrooms")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPetFriendly")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParkId")
                        .HasColumnType("int");

                    b.Property<int?>("ParkId1")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ParkId1");

                    b.ToTable("Playgrounds");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "",
                            CityId = 1,
                            Name = "Adventure Cove",
                            State = ""
                        },
                        new
                        {
                            Id = 2,
                            Address = "",
                            CityId = 1,
                            Name = "Sunny Meadows Park",
                            State = ""
                        },
                        new
                        {
                            Id = 3,
                            Address = "",
                            CityId = 2,
                            Name = "Jungle Jumper Playground",
                            State = ""
                        },
                        new
                        {
                            Id = 4,
                            Address = "",
                            CityId = 2,
                            Name = "Splash & Dash Park",
                            State = ""
                        },
                        new
                        {
                            Id = 5,
                            Address = "",
                            CityId = 3,
                            Name = "Little Explorers Park",
                            State = ""
                        },
                        new
                        {
                            Id = 6,
                            Address = "",
                            CityId = 3,
                            Name = "Rainbow Slide Haven",
                            State = ""
                        });
                });

            modelBuilder.Entity("PNWResource.API.Entities.PlaygroundEvent", b =>
                {
                    b.Property<int>("PlaygroundId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("PlaygroundId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("PlaygroundEvent");
                });

            modelBuilder.Entity("PNWResource.API.Entities.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SchoolType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("PNWResource.API.Entities.SchoolEvent", b =>
                {
                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("SchoolId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("SchoolEvent");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Zoo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<bool?>("HasChildrenArea")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Zoos");
                });

            modelBuilder.Entity("PNWResource.API.Entities.ZooEvent", b =>
                {
                    b.Property<int>("ZooId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("ZooId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("ZooEvent");
                });

            modelBuilder.Entity("PNWResource.API.Entities.DaycareCenter", b =>
                {
                    b.HasOne("PNWResource.API.Entities.City", "City")
                        .WithMany("DaycareCenters")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("City");
                });

            modelBuilder.Entity("PNWResource.API.Entities.DaycareCenterEvent", b =>
                {
                    b.HasOne("PNWResource.API.Entities.DaycareCenter", "DaycareCenter")
                        .WithMany("DaycareCenterEvents")
                        .HasForeignKey("DaycareCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PNWResource.API.Entities.Event", "Event")
                        .WithMany("DaycareCenterEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DaycareCenter");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Event", b =>
                {
                    b.HasOne("PNWResource.API.Entities.City", "City")
                        .WithMany("Events")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("City");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Library", b =>
                {
                    b.HasOne("PNWResource.API.Entities.City", "City")
                        .WithMany("Librarys")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("City");
                });

            modelBuilder.Entity("PNWResource.API.Entities.LibraryEvent", b =>
                {
                    b.HasOne("PNWResource.API.Entities.Event", "Event")
                        .WithMany("LibraryEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PNWResource.API.Entities.Library", "Library")
                        .WithMany("LibraryEvents")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Library");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Park", b =>
                {
                    b.HasOne("PNWResource.API.Entities.City", "City")
                        .WithMany("Parks")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("PNWResource.API.Entities.Playground", "Playground")
                        .WithOne()
                        .HasForeignKey("PNWResource.API.Entities.Park", "PlaygroundId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("City");

                    b.Navigation("Playground");
                });

            modelBuilder.Entity("PNWResource.API.Entities.ParkEvent", b =>
                {
                    b.HasOne("PNWResource.API.Entities.Event", "Event")
                        .WithMany("ParkEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PNWResource.API.Entities.Park", "Park")
                        .WithMany("ParkEvents")
                        .HasForeignKey("ParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Park");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Playground", b =>
                {
                    b.HasOne("PNWResource.API.Entities.City", "City")
                        .WithMany("Playgrounds")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("PNWResource.API.Entities.Park", "Park")
                        .WithMany()
                        .HasForeignKey("ParkId1");

                    b.Navigation("City");

                    b.Navigation("Park");
                });

            modelBuilder.Entity("PNWResource.API.Entities.PlaygroundEvent", b =>
                {
                    b.HasOne("PNWResource.API.Entities.Event", "Event")
                        .WithMany("PlaygroundEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PNWResource.API.Entities.Playground", "Playground")
                        .WithMany("PlaygroundEvents")
                        .HasForeignKey("PlaygroundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Playground");
                });

            modelBuilder.Entity("PNWResource.API.Entities.School", b =>
                {
                    b.HasOne("PNWResource.API.Entities.City", "City")
                        .WithMany("Schools")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("City");
                });

            modelBuilder.Entity("PNWResource.API.Entities.SchoolEvent", b =>
                {
                    b.HasOne("PNWResource.API.Entities.Event", "Event")
                        .WithMany("SchoolEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PNWResource.API.Entities.School", "School")
                        .WithMany("SchoolEvents")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("School");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Zoo", b =>
                {
                    b.HasOne("PNWResource.API.Entities.City", "City")
                        .WithMany("Zoos")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("City");
                });

            modelBuilder.Entity("PNWResource.API.Entities.ZooEvent", b =>
                {
                    b.HasOne("PNWResource.API.Entities.Event", "Event")
                        .WithMany("ZooEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PNWResource.API.Entities.Zoo", "Zoo")
                        .WithMany("ZooEvents")
                        .HasForeignKey("ZooId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Zoo");
                });

            modelBuilder.Entity("PNWResource.API.Entities.City", b =>
                {
                    b.Navigation("DaycareCenters");

                    b.Navigation("Events");

                    b.Navigation("Librarys");

                    b.Navigation("Parks");

                    b.Navigation("Playgrounds");

                    b.Navigation("Schools");

                    b.Navigation("Zoos");
                });

            modelBuilder.Entity("PNWResource.API.Entities.DaycareCenter", b =>
                {
                    b.Navigation("DaycareCenterEvents");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Event", b =>
                {
                    b.Navigation("DaycareCenterEvents");

                    b.Navigation("LibraryEvents");

                    b.Navigation("ParkEvents");

                    b.Navigation("PlaygroundEvents");

                    b.Navigation("SchoolEvents");

                    b.Navigation("ZooEvents");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Library", b =>
                {
                    b.Navigation("LibraryEvents");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Park", b =>
                {
                    b.Navigation("ParkEvents");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Playground", b =>
                {
                    b.Navigation("PlaygroundEvents");
                });

            modelBuilder.Entity("PNWResource.API.Entities.School", b =>
                {
                    b.Navigation("SchoolEvents");
                });

            modelBuilder.Entity("PNWResource.API.Entities.Zoo", b =>
                {
                    b.Navigation("ZooEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
