using Jedster.CoreBuisness;

namespace Jedster.UseCases.PluginInterfaces;

public interface ITextBookTypesRepository
{
    Task<IEnumerable<TextBookType>> GetTextBookTypes();
    Task<TextBookType> GetTextBookTypeById(int id);
    Task RegisterTextBookType(TextBookType textBookType);
    Task UpdateTextBookType(TextBookType textBookType);
    Task DeleteTextBookType(int id);
}