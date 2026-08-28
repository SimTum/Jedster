using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Groups;

public class DeleteGroupUseCase(IGroupRepository groupRepository) : IDeleteGroupUseCase
{
    public async Task ExecuteAsync(int groupId)
    {
        await groupRepository.DeleteGroupByIdAsync(groupId);
    }
}