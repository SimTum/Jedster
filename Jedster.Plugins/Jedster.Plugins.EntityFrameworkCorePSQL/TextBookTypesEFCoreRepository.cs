using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class TextBookTypesEFCoreRepository(IDbContextFactory<JedsterContext> _factory) : ITextBookTypesRepository
{
    public Task<IEnumerable<TextBookType>> GetTextBookTypes()
    {
        throw new NotImplementedException();
    }

    public Task<TextBookType> GetTextBookTypeById(int id)
    {
        throw new NotImplementedException();
    }

    public Task RegisterTextBookType(TextBookType textBookType)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTextBookType(TextBookType textBookType)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTextBookType(int id)
    {
        throw new NotImplementedException();
    }
}