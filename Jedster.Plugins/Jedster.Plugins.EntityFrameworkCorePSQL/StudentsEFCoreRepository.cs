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

    public Task<Student> GetStudentByIdAsync(int studentId)
    {
        throw new NotImplementedException();
    }

    public Task EditStudentAsyc(Student student)
    {
        throw new NotImplementedException();
    }

    public Task RegisterStudentAsync(Student student)
    {
        throw new NotImplementedException();
    }

    public Task DeleteStudenteById(int studentId)
    {
        throw new NotImplementedException();
    }
}