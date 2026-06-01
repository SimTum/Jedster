using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class GroupsEfCoreRepository(IDbContextFactory<JedsterContext> _factory) : IGroupRepository
{
    public async Task<IEnumerable<Group>> GetGroupsByNameAsync(string nome)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Groups?.Include(g => g.Teacher).ToListAsync()!;
    }

    public async Task RegisterGroup(Group group)
    {
        await using var db = await _factory.CreateDbContextAsync();
        if (db.Groups != null) db.Groups.Add(group);
        await db.SaveChangesAsync();
    }

    public async Task<Group?> GetGroupByIdAsync(int groupId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Groups.FindAsync(groupId)??  null;
    }

    public Task EditGroupAsync(Group group)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteGroupByIdAsync(int groupId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        db.Groups?.Remove(await db.Groups.FindAsync(groupId) ?? throw new InvalidOperationException());
        await db.SaveChangesAsync();
        ;
    }
}