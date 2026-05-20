using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class TeachersEfCoreRepository(IDbContextFactory<JedsterContext> contextFactorySource) : ITeacherRepository
{
    
    private readonly IDbContextFactory<JedsterContext> _factory = contextFactorySource;
    
    public async Task<IEnumerable<Teacher>> GetTeachersByNameAsync(string name)
    {
        await using var db = _factory.CreateDbContext();
        return await db.Teachers?.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToListAsync();
    }

    public async Task RegisterTeacherAsync(Teacher teacher)
    {
        await using var db = _factory.CreateDbContext();
        db.Teachers?.Add(teacher);
        await db.SaveChangesAsync();
    }

    public Task EditTeacherAsync(Teacher teacher)
    {
        throw new NotImplementedException();
    }

    public async Task<Teacher?> GetTeacherByIdAsync(int id)
    {
        await using var db = _factory.CreateDbContext();
        return await db.Teachers?.FindAsync(id)!??  null;
    }

    public async Task DeleteTeacherByIdAsync(int id)
    {
        await using var db = await _factory.CreateDbContextAsync();
        db.Teachers?.Remove(await db.Teachers.FindAsync(id));
        await db.SaveChangesAsync();
    }
}
