using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Materials;

public class EditMaterialUseCase(IMaterialRepository materialRepository) : IEditMaterialUseCase
{
    public async Task ExecuteAsync(Material material)
    {
        await materialRepository.EditMaterialAsync(material);
    }
}