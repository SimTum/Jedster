using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Groups;

public class RegisterGroupUseCase(IGroupRepository groupRepository) : IRegisterGroupUseCase
{
    public async Task ExecuteAsync(Group group)
    {   
        await groupRepository.RegisterGroup(group); 
    }
}