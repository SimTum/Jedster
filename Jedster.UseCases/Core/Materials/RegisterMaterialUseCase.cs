using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Materials;

public class RegisterMaterialUseCase(IMaterialRepository materialRepository) : IRegisterMaterialUseCase
{
    public async Task ExecuteAsync(Textbook material)
    {
        await materialRepository.RegisterMaterialAsync(material);
    }
}