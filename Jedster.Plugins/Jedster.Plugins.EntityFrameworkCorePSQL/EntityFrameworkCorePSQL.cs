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
    public DbSet<Material>? Textbooks { get; set; }

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
            .WithOne(teacher => teacher.Teacher)
            .HasForeignKey(teacher => teacher.GroupId);
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
            .WithOne(group  => group.Group)
            .HasForeignKey(group => group.StudentId);
        modelBuilder.Entity<Student>()
            .HasOne(student => student.Group)
            .WithMany(group => group.Students)
            .HasForeignKey(student => student.GroupId);
        
        modelBuilder.Entity<Student>()
            .HasKey(student => new { student.StudentId});

        modelBuilder.Entity<Student>()
            .HasMany(student => student.Materials)
            .WithOne(student => student.Student)
            .HasForeignKey(student => student.TextbookId);
        
        modelBuilder.Entity<Material>()
            .HasOne(textbook => textbook.Student)
            .WithMany(student => student.Materials)
            .HasForeignKey(textbook => textbook.StudentId);
        modelBuilder.Entity<Material>()
            .HasKey(textbook => new { textbook.TextbookId });
    }
    
}