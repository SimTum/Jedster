using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class MaterialEfCoreRepository(IDbContextFactory<JedsterContext> _factory) : IMaterialRepository
{
    public async Task<IEnumerable<Textbook>> GetMaterialsByNameAsync(string materialName)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Textbooks.Include(t => t.Student).Include(t => t.TextbookType).ToListAsync();
    }

    public async Task<Textbook> GetMateiralByIdAsync(int materialId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Textbooks.FindAsync(materialId)??  null;
    }

    public async Task RegisterMaterialAsync(Textbook material)
    {
        await using var db = await _factory.CreateDbContextAsync();
        if (db.Textbooks != null) db.Textbooks.Add(material);
        await db.SaveChangesAsync();
    }

    public async Task EditMaterialAsync(Textbook material)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var textbook = await db.Textbooks.FindAsync(material.TextbookId);
        if (textbook != null)
        {
            textbook.Title = material.Title;
            textbook.TextbookTypeId = material.TextbookTypeId;
            textbook.StudentId = material.StudentId;
            textbook.HoursSpent = material.HoursSpent;
            textbook.Engagement = material.Engagement;

            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteMaterialByIdAsync(int materialId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        db.Textbooks?.Remove(await db.Textbooks.FindAsync(materialId));
        await db.SaveChangesAsync();
    }
}