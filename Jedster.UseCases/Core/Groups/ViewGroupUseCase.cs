using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Groups;

public class ViewGroupUseCase(IGroupRepository groupRepository) : IViewGroupUseCase
{
    public async Task<IEnumerable<Group>> ExecuteAsync(string groupName = "")
    {
        return await groupRepository.GetGroupsByNameAsync(groupName);
    }

    public async Task<Group?> ExecuteAsync(int groupId)
    {
        return await groupRepository.GetGroupByIdAsync(groupId);
    }
}