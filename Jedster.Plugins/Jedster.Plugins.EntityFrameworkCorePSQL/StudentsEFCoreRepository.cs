using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class StudentsEfCoreRepository(IDbContextFactory<JedsterContext> _factory) : IStudentRepository
{
    public async Task<IEnumerable<Student>> GetStudentsByNameAsync(string name)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Students?.Include(s => s.Textbooks != null ? s.Textbooks : null)
            .Include(s => s.Group != null ? s.Group : null).ThenInclude(g => g.Teacher)
            .Include(s => s.Contract).ToListAsync()!;
    }

    public async Task<Student?> GetStudentByIdAsync(int studentId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Students.FindAsync(studentId) ?? null;
    }

    public async Task EditStudentAsyc(Student student)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var existingStudent = await db.Students.FindAsync(student.StudentId);
        if (existingStudent != null)
        {
            existingStudent.Name = student.Name;
            existingStudent.RG = student.RG;
            existingStudent.CPF = student.CPF;
            existingStudent.BirthDate = student.BirthDate;
            existingStudent.GroupId = student.GroupId;

            await db.SaveChangesAsync();
        }
    }

    public async Task RegisterStudentAsync(Student student)
    {
        await using var db = await _factory.CreateDbContextAsync();
        if (db.Students != null) db.Students.Add(student);
        await db.SaveChangesAsync();
        ;
    }

    public async Task DeleteStudenteById(int studentId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        db.Students?.Remove(await db.Students.FindAsync(studentId) ?? throw new InvalidOperationException());
        await db.SaveChangesAsync();
    }
}