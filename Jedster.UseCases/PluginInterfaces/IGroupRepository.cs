using System;
using Jedster.CoreBusiness;

namespace Jedster.UseCases.PluginInterfaces;

public interface IGroupRepository
{
    Task<IEnumerable<Group>> GetGroupsByNameAsync(string name);

    Task RegisterGroup(Group group);
    Task<Group?> GetGroupByIdAsync(int groupId);
    Task EditGroupAsync(Group group);
    Task DeleteGroupByIdAsync(int groupId);
}
