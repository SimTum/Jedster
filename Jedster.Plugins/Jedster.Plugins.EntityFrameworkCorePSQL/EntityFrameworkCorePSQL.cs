using Jedster.CoreBuisness;
using Jedster.CoreBusiness;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class JedsterContext : DbContext
{
    public JedsterContext(DbContextOptions<JedsterContext> options) : base(options)
    {
    }

    public DbSet<Teacher>? Teachers { get; set; }
    public DbSet<Group>? Groups { get; set; }
    public DbSet<Student>? Students { get; set; }
    public DbSet<Textbook>? Textbooks { get; set; }
    public DbSet<Lesson>? Lessons { get; set; }
    public DbSet<Attendance>? Attendances { get; set; }
    public DbSet<Contract>? Contracts { get; set; }
    public DbSet<TextBookType>? TextBookTypes { get; set; }

    //Connections
    // public DbSet<TeacherGroups>? TeacherGroups { get; set; }
    // public DbSet<GroupStudents>? StudentsGroups { get; set; }
    // public DbSet<StudentMaterials>? StudentMaterials { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Teacher>()
            .HasKey(teacher => new { teacher.TeacherId });
        //one-to-many Teacher-groups
        //one TEACHER has many GROUPS. And each GROUP has one TEACHER
        modelBuilder.Entity<Teacher>()
            .HasMany(teacher => teacher.Groups)
            .WithOne(group => group.Teacher)
            .HasForeignKey(group => group.TeacherId);
        //one GROUP always has one TEACHER. But that TEACHER can have many GROUPS
        modelBuilder.Entity<Group>()
            .HasOne(group => group.Teacher)
            .WithMany(teacher => teacher.Groups)
            .HasForeignKey(group => group.TeacherId);

        modelBuilder.Entity<Group>()
            .HasKey(group => new { group.GroupId });


        // Same deal, but for GROUP that can have many STUDENTS
        modelBuilder.Entity<Group>()
            .HasMany(group => group.Students)
            .WithOne(student => student.Group)
            .HasForeignKey(student => student.StudentId);
        modelBuilder.Entity<Student>()
            .HasOne(student => student.Group)
            .WithMany(group => group.Students)
            .HasForeignKey(student => student.GroupId);

        modelBuilder.Entity<Student>()
            .HasKey(student => new { student.StudentId });

        modelBuilder.Entity<Student>()
            .HasMany(student => student.Textbooks)
            .WithOne()
            .HasForeignKey(textbook => textbook.StudentId);

        modelBuilder.Entity<Student>()
            .HasOne(student => student.Contract)
            .WithOne(contract => contract.Student)
            .HasForeignKey<Contract>(contract => contract.StudentId);

        modelBuilder.Entity<Textbook>()
            .HasKey(textbook => new { textbook.TextbookId });

        modelBuilder.Entity<Textbook>()
            .HasOne(textbook => textbook.TextbookData)
            .WithMany()
            .HasForeignKey(textbook => textbook.TextbookTypeId);

        modelBuilder.Entity<Lesson>()
            .HasKey(lesson => new { lesson.LessonId });

        modelBuilder.Entity<Lesson>()
            .HasOne(lesson => lesson.Group)
            .WithMany()
            .HasForeignKey(lesson => lesson.GroupId);

        modelBuilder.Entity<Attendance>()
            .HasKey(attendance => attendance.EntryId);

        modelBuilder.Entity<Attendance>()
            .HasOne(attendance => attendance.Lesson)
            .WithMany()
            .HasForeignKey(attendance => attendance.LessonId);

        modelBuilder.Entity<Attendance>()
            .HasOne(attendance => attendance.Student)
            .WithMany()
            .HasForeignKey(attendance => attendance.StudentId);
    }
}