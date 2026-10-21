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


        // GROUP - STUDENTS
        modelBuilder.Entity<Group>()
            .HasMany(group => group.Students)
            .WithOne(student => student.Group)
            .HasForeignKey(student => student.GroupId);

        // STUDENT
        
        modelBuilder.Entity<Student>()
            .HasKey(student => new { student.StudentId });
        modelBuilder.Entity<Student>()
            .HasMany(student => student.Textbooks)
            .WithOne(textbook => textbook.Student )
            .HasForeignKey(textbook => textbook.StudentId);

        //CONTRACT
        
        modelBuilder.Entity<Contract>()
            .HasKey(contract => new { contract.ContractId });
        
        modelBuilder.Entity<Student>()
            .HasOne(student => student.Contract)
            .WithOne(contract => contract.Student)
            .HasForeignKey<Contract>(contract => contract.StudentId);

        //TEXTBOOK
        
        modelBuilder.Entity<Textbook>()
            .HasKey(textbook => new { textbook.TextbookId });

        modelBuilder.Entity<Textbook>()
            .HasOne(textbook => textbook.TextbookType)
            .WithMany(tt => tt.Textbooks)
            .HasForeignKey(textbook => textbook.TextbookTypeId);
        
        //TEXTBOOKTYPE
        
        modelBuilder.Entity<TextBookType>()
            .HasKey(textbookType => new { textbookType.Id });
        
        modelBuilder.Entity<TextBookType>()
            .HasMany(textbookType => textbookType.Textbooks)
            .WithOne(textbook => textbook.TextbookType)
            .HasForeignKey(textbook => textbook.TextbookTypeId);
        
        //LESSON
        
        modelBuilder.Entity<Lesson>()
            .HasKey(lesson => new { lesson.LessonId });
        
        modelBuilder.Entity<Lesson>()
            .HasOne(lesson => lesson.Group)
            .WithMany(group => group.Lessons)
            .HasForeignKey(lesson => lesson.GroupId);
        
        modelBuilder.Entity<Lesson>()
            .HasOne(lesson => lesson.Teacher)
            .WithMany(t => t.Lessons)
            .HasForeignKey(lesson => lesson.TeacherId);
        
        // Many-to-many relation through join 
        modelBuilder.Entity<Lesson>()
            .HasMany(l => l.Students)
            .WithMany(s => s.Lessons)
            .UsingEntity<Dictionary<string, object>>(
                "StudentLesson",
                l => l.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
                r => r.HasOne<Lesson>().WithMany().HasForeignKey("LessonId"),
                j => j.HasKey("LessonId", "StudentId")
            );
        
        //ATTENDANCE
        
        modelBuilder.Entity<Attendance>()
            .HasKey(attendance => attendance.EntryId);

        modelBuilder.Entity<Attendance>()
            .HasOne(attendance => attendance.Lesson)
            .WithMany(l => l.Attendances)
            .HasForeignKey(attendance => attendance.LessonId);

        modelBuilder.Entity<Attendance>()
            .HasOne(attendance => attendance.Student)
            .WithMany(s => s.Attendance)
            .HasForeignKey(attendance => attendance.StudentId);

        modelBuilder.Entity<Attendance>()
            .HasOne(attendance => attendance.Teacher)
            .WithMany(t => t.Attendance)
            .HasForeignKey(attendance => attendance.TeacherId);
        
     
    }
}