using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class MaterialEfCoreRepository(IDbContextFactory<JedsterContext> _factory) : IMaterialRepository
{
    public async Task<IEnumerable<Material>> GetMaterialsByNameAsync(string materialName)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Textbooks?.ToListAsync()!;
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