using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class TextBookTypesEFCoreRepository(IDbContextFactory<JedsterContext> _factory) : ITextBookTypesRepository
{
    public async Task<IEnumerable<TextBookType>> GetTextBookTypes()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.TextBookTypes?.ToListAsync() ?? null;
    }

    public async Task<TextBookType> GetTextBookTypeById(int id)
    {
        await using var db =  _factory.CreateDbContext();
        return await db.TextBookTypes?.FirstOrDefaultAsync(t => t.Id == id) ?? null;
        
    }

    public async Task RegisterTextBookType(TextBookType textBookType)
    {
        await using var db =  _factory.CreateDbContext();
        db.TextBookTypes.Add(textBookType);
        await db.SaveChangesAsync();
    }

    public async Task UpdateTextBookType(TextBookType textBookType)
    {
        await using var db =  _factory.CreateDbContext();
        db.TextBookTypes.Update(textBookType);
        await db.SaveChangesAsync();
    }

    public async Task DeleteTextBookType(int id)
    {
        await using var db =  _factory.CreateDbContext();
        var textBookType = await db.TextBookTypes?.FirstOrDefaultAsync(t => t.Id == id);
        if (textBookType != null)
        {
            db.TextBookTypes.Remove(textBookType);
            await db.SaveChangesAsync();
        }
    }
}