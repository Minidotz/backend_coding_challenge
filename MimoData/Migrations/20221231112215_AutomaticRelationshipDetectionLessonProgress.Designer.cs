﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MimoData.DbContexts;

#nullable disable

namespace MimoData.Migrations
{
    [DbContext(typeof(MimoContext))]
    [Migration("20221231112215_AutomaticRelationshipDetectionLessonProgress")]
    partial class AutomaticRelationshipDetectionLessonProgress
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("MimoDomain.Achievement", b =>
                {
                    b.Property<int>("AchievementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Units")
                        .HasColumnType("INTEGER");

                    b.HasKey("AchievementId");

                    b.HasIndex("CourseId");

                    b.ToTable("Achievements");

                    b.HasData(
                        new
                        {
                            AchievementId = 1,
                            Name = "Complete 5 lessons",
                            Type = "Lesson",
                            Units = 5
                        },
                        new
                        {
                            AchievementId = 2,
                            Name = "Complete 25 lessons",
                            Type = "Lesson",
                            Units = 25
                        },
                        new
                        {
                            AchievementId = 3,
                            Name = "Complete 50 lessons",
                            Type = "Lesson",
                            Units = 50
                        },
                        new
                        {
                            AchievementId = 4,
                            Name = "Complete 1 chapter",
                            Type = "Chapter",
                            Units = 1
                        },
                        new
                        {
                            AchievementId = 5,
                            Name = "Complete 5 chapters",
                            Type = "Chapter",
                            Units = 5
                        },
                        new
                        {
                            AchievementId = 6,
                            CourseId = 1,
                            Name = "Complete the Swift course",
                            Type = "Course",
                            Units = 1
                        },
                        new
                        {
                            AchievementId = 7,
                            CourseId = 2,
                            Name = "Complete the Javascript course",
                            Type = "Course",
                            Units = 1
                        },
                        new
                        {
                            AchievementId = 8,
                            CourseId = 3,
                            Name = "Complete the C# course",
                            Type = "Course",
                            Units = 1
                        });
                });

            modelBuilder.Entity("MimoDomain.Chapter", b =>
                {
                    b.Property<int>("ChapterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Sort")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChapterId");

                    b.HasIndex("CourseId");

                    b.ToTable("Chapters");

                    b.HasData(
                        new
                        {
                            ChapterId = 1,
                            CourseId = 1,
                            Name = "Chapter 1",
                            Sort = 1
                        },
                        new
                        {
                            ChapterId = 2,
                            CourseId = 1,
                            Name = "Chapter 2",
                            Sort = 2
                        },
                        new
                        {
                            ChapterId = 3,
                            CourseId = 2,
                            Name = "Chapter 1",
                            Sort = 1
                        },
                        new
                        {
                            ChapterId = 4,
                            CourseId = 2,
                            Name = "Chapter 2",
                            Sort = 2
                        },
                        new
                        {
                            ChapterId = 5,
                            CourseId = 3,
                            Name = "Chapter 1",
                            Sort = 1
                        },
                        new
                        {
                            ChapterId = 6,
                            CourseId = 3,
                            Name = "Chapter 2",
                            Sort = 2
                        });
                });

            modelBuilder.Entity("MimoDomain.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            Name = "Swift"
                        },
                        new
                        {
                            CourseId = 2,
                            Name = "Javascript"
                        },
                        new
                        {
                            CourseId = 3,
                            Name = "C#"
                        });
                });

            modelBuilder.Entity("MimoDomain.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ChapterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Sort")
                        .HasColumnType("INTEGER");

                    b.HasKey("LessonId");

                    b.HasIndex("ChapterId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("MimoDomain.LessonProgress", b =>
                {
                    b.Property<int>("LessonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.HasKey("LessonId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("LessonProgress");
                });

            modelBuilder.Entity("MimoDomain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            FirstName = "Stratos",
                            LastName = "Paraskevaidis"
                        });
                });

            modelBuilder.Entity("MimoDomain.UserAchievement", b =>
                {
                    b.Property<int>("AchievementId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CompletedDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.HasKey("AchievementId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAchievement");
                });

            modelBuilder.Entity("MimoDomain.Achievement", b =>
                {
                    b.HasOne("MimoDomain.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("MimoDomain.Chapter", b =>
                {
                    b.HasOne("MimoDomain.Course", null)
                        .WithMany("Chapters")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MimoDomain.Lesson", b =>
                {
                    b.HasOne("MimoDomain.Chapter", null)
                        .WithMany("Lessons")
                        .HasForeignKey("ChapterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MimoDomain.LessonProgress", b =>
                {
                    b.HasOne("MimoDomain.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MimoDomain.User", "User")
                        .WithMany("UserLessons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MimoDomain.UserAchievement", b =>
                {
                    b.HasOne("MimoDomain.Achievement", "Achievement")
                        .WithMany()
                        .HasForeignKey("AchievementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MimoDomain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Achievement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MimoDomain.Chapter", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("MimoDomain.Course", b =>
                {
                    b.Navigation("Chapters");
                });

            modelBuilder.Entity("MimoDomain.User", b =>
                {
                    b.Navigation("UserLessons");
                });
#pragma warning restore 612, 618
        }
    }
}
