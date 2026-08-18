using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class StudentsEfCoreRepository(IDbContextFactory<JedsterContext> _factory) : IStudentRepository
{
    public async Task<IEnumerable<Student>> GetStudentsByNameAsync(string name)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Students?.ToListAsync()!;
    }

    public async Task<Student?> GetStudentByIdAsync(int studentId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Students.FindAsync(studentId)??  null;
        
    }

    public Task EditStudentAsyc(Student student)
    {
        throw new NotImplementedException();
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