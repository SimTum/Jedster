using Jedster.CoreBuisness;
using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class TeachersEfCoreRepository(IDbContextFactory<JedsterContext> _factory) : ITeacherRepository
{
    public async Task<IEnumerable<Teacher>> GetTeachersByNameAsync(string name)
    {
        await using var db =  await _factory.CreateDbContextAsync();
        return await db.Teachers?.Include(t => t.Groups).ThenInclude(g => g.Students).ToListAsync()!;
    }

    public async Task RegisterTeacherAsync(Teacher teacher)
    {
        await using var db = _factory.CreateDbContext();
        if (db.Teachers != null) db.Teachers.Add(teacher);
        await db.SaveChangesAsync();
    }

    public async Task EditTeacherAsync(Teacher teacher)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var _teacher = await db.Teachers.FindAsync(teacher.TeacherId);
        if (_teacher != null)
        {
                _teacher.Name = teacher.Name;
                _teacher.Email = teacher.Email;
                _teacher.BirthDate = teacher.BirthDate;
                _teacher.CPF = teacher.CPF;
                _teacher.RG = teacher.RG;

            
            await db.SaveChangesAsync(); 
        }
    }

    public async Task<Teacher?> GetTeacherByIdAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Teachers.FindAsync(id)??  null;
        
    }

    public async Task DeleteTeacherByIdAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        db.Teachers?.Remove(await db.Teachers.FindAsync(id));
        await db.SaveChangesAsync();
    }
}
