using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MimoDomain;

namespace MimoData.DbContexts
{
    public class MimoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Achievement> Achievements { get; set; }

        public MimoContext(DbContextOptions<MimoContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Server=YourServer; Database=YourDb; Integrated Security=true; MultipleActiveResultSets=true; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed Data
            modelBuilder.Entity<User>().HasData(new User { UserId = 1, FirstName = "Stratos", LastName = "Paraskevaidis" });

            var courses = new Course[]
            {
                new Course { CourseId = 1, Name = "Swift"},
                new Course { CourseId = 2, Name = "Javascript"},
                new Course { CourseId = 3, Name = "C#"}
            };
            modelBuilder.Entity<Course>().HasData(courses);
            var chapters = new Chapter[]
            {
                new Chapter {ChapterId = 1, CourseId = 1, Name = "Chapter 1", Sort = 1},
                new Chapter {ChapterId = 2, CourseId = 1, Name = "Chapter 2", Sort = 2},
                new Chapter {ChapterId = 3, CourseId = 2, Name = "Chapter 1", Sort = 1},
                new Chapter {ChapterId = 4, CourseId = 2, Name = "Chapter 2", Sort = 2},
                new Chapter {ChapterId = 5, CourseId = 3, Name = "Chapter 1", Sort = 1},
                new Chapter {ChapterId = 6, CourseId = 3, Name = "Chapter 2", Sort = 2},
            };
            modelBuilder.Entity<Chapter>().HasData(chapters);
            var lessons = new Lesson[]
            {
                new Lesson { LessonId = 1, ChapterId = 1, Name = "Lesson 1", Sort = 1},
                new Lesson { LessonId = 2, ChapterId = 1, Name = "Lesson 2", Sort = 2},
                new Lesson { LessonId = 3, ChapterId = 1, Name = "Lesson 3", Sort = 3},
                new Lesson { LessonId = 4, ChapterId = 1, Name = "Lesson 4", Sort = 4},
                new Lesson { LessonId = 5, ChapterId = 1, Name = "Lesson 5", Sort = 5},
                new Lesson { LessonId = 6, ChapterId = 1, Name = "Lesson 6", Sort = 6},
                new Lesson { LessonId = 7, ChapterId = 1, Name = "Lesson 7", Sort = 7},
                new Lesson { LessonId = 8, ChapterId = 1, Name = "Lesson 8", Sort = 8},
                new Lesson { LessonId = 9, ChapterId = 1, Name = "Lesson 9", Sort = 9},
                new Lesson { LessonId = 10, ChapterId = 1, Name = "Lesson 10", Sort = 10},
                new Lesson { LessonId = 11, ChapterId = 2, Name = "Lesson 1", Sort = 1},
                new Lesson { LessonId = 12, ChapterId = 2, Name = "Lesson 2", Sort = 2},
                new Lesson { LessonId = 13, ChapterId = 2, Name = "Lesson 3", Sort = 3},
                new Lesson { LessonId = 14, ChapterId = 2, Name = "Lesson 4", Sort = 4},
                new Lesson { LessonId = 15, ChapterId = 2, Name = "Lesson 5", Sort = 5},
                new Lesson { LessonId = 16, ChapterId = 2, Name = "Lesson 6", Sort = 6},
                new Lesson { LessonId = 17, ChapterId = 2, Name = "Lesson 7", Sort = 7},
                new Lesson { LessonId = 18, ChapterId = 2, Name = "Lesson 8", Sort = 8},
                new Lesson { LessonId = 19, ChapterId = 2, Name = "Lesson 9", Sort = 9},
                new Lesson { LessonId = 20, ChapterId = 2, Name = "Lesson 10", Sort = 10},
                new Lesson { LessonId = 21, ChapterId = 3, Name = "Lesson 1", Sort = 1},
                new Lesson { LessonId = 22, ChapterId = 3, Name = "Lesson 2", Sort = 2},
                new Lesson { LessonId = 23, ChapterId = 3, Name = "Lesson 3", Sort = 3},
                new Lesson { LessonId = 24, ChapterId = 3, Name = "Lesson 4", Sort = 4},
                new Lesson { LessonId = 25, ChapterId = 3, Name = "Lesson 5", Sort = 5},
                new Lesson { LessonId = 26, ChapterId = 3, Name = "Lesson 6", Sort = 6},
                new Lesson { LessonId = 27, ChapterId = 3, Name = "Lesson 7", Sort = 7},
                new Lesson { LessonId = 28, ChapterId = 3, Name = "Lesson 8", Sort = 8},
                new Lesson { LessonId = 29, ChapterId = 3, Name = "Lesson 9", Sort = 9},
                new Lesson { LessonId = 30, ChapterId = 3, Name = "Lesson 10", Sort = 10},
                new Lesson { LessonId = 31, ChapterId = 4, Name = "Lesson 1", Sort = 1},
                new Lesson { LessonId = 32, ChapterId = 4, Name = "Lesson 2", Sort = 2},
                new Lesson { LessonId = 33, ChapterId = 4, Name = "Lesson 3", Sort = 3},
                new Lesson { LessonId = 34, ChapterId = 4, Name = "Lesson 4", Sort = 4},
                new Lesson { LessonId = 35, ChapterId = 4, Name = "Lesson 5", Sort = 5},
                new Lesson { LessonId = 36, ChapterId = 4, Name = "Lesson 6", Sort = 6},
                new Lesson { LessonId = 37, ChapterId = 4, Name = "Lesson 7", Sort = 7},
                new Lesson { LessonId = 38, ChapterId = 4, Name = "Lesson 8", Sort = 8},
                new Lesson { LessonId = 39, ChapterId = 4, Name = "Lesson 9", Sort = 9},
                new Lesson { LessonId = 40, ChapterId = 4, Name = "Lesson 10", Sort = 10},
                new Lesson { LessonId = 41, ChapterId = 5, Name = "Lesson 1", Sort = 1},
                new Lesson { LessonId = 42, ChapterId = 5, Name = "Lesson 2", Sort = 2},
                new Lesson { LessonId = 43, ChapterId = 5, Name = "Lesson 3", Sort = 3},
                new Lesson { LessonId = 44, ChapterId = 5, Name = "Lesson 4", Sort = 4},
                new Lesson { LessonId = 45, ChapterId = 5, Name = "Lesson 5", Sort = 5},
                new Lesson { LessonId = 46, ChapterId = 5, Name = "Lesson 6", Sort = 6},
                new Lesson { LessonId = 47, ChapterId = 5, Name = "Lesson 7", Sort = 7},
                new Lesson { LessonId = 48, ChapterId = 5, Name = "Lesson 8", Sort = 8},
                new Lesson { LessonId = 49, ChapterId = 5, Name = "Lesson 9", Sort = 9},
                new Lesson { LessonId = 50, ChapterId = 5, Name = "Lesson 10", Sort = 10},
                new Lesson { LessonId = 51, ChapterId = 6, Name = "Lesson 1", Sort = 1},
                new Lesson { LessonId = 52, ChapterId = 6, Name = "Lesson 2", Sort = 2},
                new Lesson { LessonId = 53, ChapterId = 6, Name = "Lesson 3", Sort = 3},
                new Lesson { LessonId = 54, ChapterId = 6, Name = "Lesson 4", Sort = 4},
                new Lesson { LessonId = 55, ChapterId = 6, Name = "Lesson 5", Sort = 5}
            };
            modelBuilder.Entity<Lesson>().HasData(lessons);
            var achievements = new Achievement[]
            {
                new Achievement { AchievementId = 1, Name = "Complete 5 lessons", Type = AchievementType.Lesson, Units = 5, CourseId = null },
                new Achievement { AchievementId = 2, Name = "Complete 25 lessons", Type = AchievementType.Lesson, Units = 25, CourseId = null },
                new Achievement { AchievementId = 3, Name = "Complete 50 lessons", Type = AchievementType.Lesson, Units = 50, CourseId = null },
                new Achievement { AchievementId = 4, Name = "Complete 1 chapter", Type = AchievementType.Chapter, Units = 1, CourseId = null },
                new Achievement { AchievementId = 5, Name = "Complete 5 chapters", Type = AchievementType.Chapter, Units = 5, CourseId = null },
                new Achievement { AchievementId = 6, Name = "Complete the Swift course", Type = AchievementType.Course, Units = 1, CourseId = 1 },
                new Achievement { AchievementId = 7, Name = "Complete the Javascript course", Type = AchievementType.Course, Units = 1, CourseId = 2 },
                new Achievement { AchievementId = 8, Name = "Complete the C# course", Type = AchievementType.Course, Units = 1, CourseId = 3 },
            };
            modelBuilder.Entity<Achievement>().HasData(achievements);

            //Entity configuration
            modelBuilder.Entity<Achievement>().Property(p => p.Type).HasConversion<string>();

            modelBuilder.Entity<CourseProgress>()
                .HasOne(cp => cp.Lesson)
                .WithMany()
                .HasForeignKey(cp => cp.LessonId);
            modelBuilder.Entity<CourseProgress>()
                .HasOne(cp => cp.User)
                .WithMany(u => u.CourseProgress)
                .HasForeignKey(cp => cp.UserId);
            modelBuilder.Entity<CourseProgress>()
                .HasOne(cp => cp.Course)
                .WithMany()
                .HasForeignKey(cp => cp.CourseId);
            modelBuilder.Entity<CourseProgress>()
                .HasOne(cp => cp.Chapter)
                .WithMany()
                .HasForeignKey(cp => cp.ChapterId);
            modelBuilder.Entity<CourseProgress>().Property(cp => cp.StartDateTime).HasDefaultValueSql("datetime()");
            modelBuilder.Entity<CourseProgress>().HasIndex(cp => new { cp.CourseId, cp.ChapterId, cp.LessonId, cp.UserId }).IsUnique();
        }
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<MimoContext>
    {
        public MimoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MimoContext>();
            optionsBuilder.UseSqlite("Data Source=MimoDatabase.db");

            return new MimoContext(optionsBuilder.Options);
        }
    }
}
