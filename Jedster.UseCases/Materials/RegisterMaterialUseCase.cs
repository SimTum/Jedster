using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Materials;

public class RegisterMaterialUseCase(IMaterialRepository materialRepository) : IRegisterMaterialUseCase
{
    public async Task ExecuteAsync(Material material)
    {
        await materialRepository.RegisterMaterialAsync(material);
    }
}