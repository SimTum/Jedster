using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Materials;

public class ViewMaterialUseCase(IMaterialRepository materialRepository) : IViewMaterialUseCase
{
    public async Task<IEnumerable<Material>> ExecuteAsync(string materialName = " ")
    {
        return await materialRepository.GetMaterialsByNameAsync(materialName);
    }

    public async Task<Material> ExecuteAsync(int materialId)
    {
        return await materialRepository.GetMateiralByIdAsync(materialId);
    }
}
