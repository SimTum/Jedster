using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Materials;

public class EditMaterialUseCase(IMaterialRepository materialRepository) : IEditMaterialUseCase
{
    public async Task ExecuteAsync(Textbook material)
    {
        await materialRepository.EditMaterialAsync(material);
    }
}