using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Materials;

public class ViewMaterialUseCase(IMaterialRepository materialRepository) : IViewMaterialUseCase
{
    public async Task<IEnumerable<Textbook>> ExecuteAsync(string materialName = " ")
    {
        return await materialRepository.GetMaterialsByNameAsync(materialName);
    }

    public async Task<Textbook> ExecuteAsync(int materialId)
    {
        return await materialRepository.GetMateiralByIdAsync(materialId);
    }
}
