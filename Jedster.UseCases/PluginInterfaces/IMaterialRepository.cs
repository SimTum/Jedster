using Jedster.CoreBusiness;

namespace Jedster.UseCases.PluginInterfaces;

public interface IMaterialRepository
{
    Task<IEnumerable<Material>> GetMaterialsByNameAsync(string materialName);
    Task<Material> GetMateiralByIdAsync(int materialId);
    Task RegisterMaterialAsync(Material material);
    Task EditMaterialAsync(Material material);
    Task DeleteMaterialByIdAsync(int materialId);
}