using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class GroupsEfCoreRepository(IDbContextFactory<JedsterContext> contextFactorySource) : IGroupRepository
{
    public Task<IEnumerable<Group>> GetGroupsByNameAsync(string nome)
    {
        throw new NotImplementedException();
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