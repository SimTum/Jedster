using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class TeachersEfCoreRepository(IDbContextFactory<JedsterContext> contextFactorySource) : ITeacherRepository
{
    public async Task<IEnumerable<Teacher>> GetTeachersByNameAsync(string name)
    {
        await using var db =  await contextFactorySource.CreateDbContextAsync();
        return await db.Teachers?.ToListAsync();
    }

    public async Task RegisterTeacherAsync(Teacher teacher)
    {
        await using var db = contextFactorySource.CreateDbContext();
        if (db.Teachers != null) db.Teachers.Add(teacher);
        await db.SaveChangesAsync();
    }

    public async Task EditTeacherAsync(Teacher teacher)
    {
        await using var db = await contextFactorySource.CreateDbContextAsync();
        var _teacher = await db.Teachers.FindAsync(teacher.TeacherId);
        if (_teacher != null)
        {
            _teacher.Name = teacher.Name;
            _teacher.Email = teacher.Email;
            
            await db.SaveChangesAsync(); 
        }
    }

    public async Task<Teacher?> GetTeacherByIdAsync(int id)
    {
        await using var db = await contextFactorySource.CreateDbContextAsync();
        return await db.Teachers.FindAsync(id)??  null;
        
    }

    public async Task DeleteTeacherByIdAsync(int id)
    {
        await using var db = await contextFactorySource.CreateDbContextAsync();
        db.Teachers?.Remove(await db.Teachers.FindAsync(id));
        await db.SaveChangesAsync();
    }
}
