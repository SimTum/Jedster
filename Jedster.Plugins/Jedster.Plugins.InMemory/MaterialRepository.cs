using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.Plugins.InMemory;

public class MaterialRepository : IMaterialRepository
{
    public Task<IEnumerable<Textbook>> GetMaterialsByNameAsync(string materialName)
    {
        throw new NotImplementedException();
    }

    public Task<Textbook> GetMateiralByIdAsync(int materialId)
    {
        throw new NotImplementedException();
    }

    public Task RegisterMaterialAsync(Textbook material)
    {
        throw new NotImplementedException();
    }

    public Task EditMaterialAsync(Textbook material)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMaterialByIdAsync(int materialId)
    {
        throw new NotImplementedException();
    }
}