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

    public async Task<Material> GetMateiralByIdAsync(int materialId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Textbooks.FindAsync(materialId)??  null;
    }

    public async Task RegisterMaterialAsync(Material material)
    {
        await using var db = await _factory.CreateDbContextAsync();
        if (db.Textbooks != null) db.Textbooks.Add(material);
        await db.SaveChangesAsync();
    }

    public Task EditMaterialAsync(Material material)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteMaterialByIdAsync(int materialId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        db.Textbooks?.Remove(await db.Textbooks.FindAsync(materialId));
        await db.SaveChangesAsync();
    }
}