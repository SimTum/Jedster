using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class GroupsEfCoreRepository(IDbContextFactory<JedsterContext> contextFactorySource) : IGroupRepository
{
    public async Task<IEnumerable<Group>> GetGroupsByNameAsync(string nome)
    {
        await using var db = await contextFactorySource.CreateDbContextAsync();
        return await db.Groups?.ToListAsync()!;
    }

    public Task RegisterGroup(Group group)
    {
        throw new NotImplementedException();
    }

    public Task<Group?> GetGroupByIdAsync(int groupId)
    {
        throw new NotImplementedException();
    }

    public Task EditGroupAsync(Group group)
    {
        throw new NotImplementedException();
    }

    public Task DeleteGroupByIdAsync(int groupId)
    {
        throw new NotImplementedException();
    }
}