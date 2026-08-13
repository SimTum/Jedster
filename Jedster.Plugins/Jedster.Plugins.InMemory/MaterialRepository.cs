using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.Plugins.InMemory;

public class MaterialRepository : IMaterialRepository
{
    public Task<IEnumerable<Material>> GetMaterialsByNameAsync(string materialName)
    {
        throw new NotImplementedException();
    }

    public Task<Material> GetMateiralByIdAsync(int materialId)
    {
        throw new NotImplementedException();
    }

    public Task RegisterMaterialAsync(Material material)
    {
        throw new NotImplementedException();
    }

    public Task EditMaterialAsync(Material material)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMaterialByIdAsync(int materialId)
    {
        throw new NotImplementedException();
    }
}