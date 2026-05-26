using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Groups;

public class EditGroupUseCase(IGroupRepository groupRepository) : IEditGroupUseCase
{
 public async Task ExecuteAsync(Group group)
 {
  await groupRepository.EditGroupAsync(group);
 }  
}