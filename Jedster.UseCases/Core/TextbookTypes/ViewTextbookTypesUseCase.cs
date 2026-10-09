using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Core.TextbookTypes;

public class ViewTextbookTypesUseCase(ITextBookTypesRepository  textBookTypesRepository) : IViewTextbookTypesUseCase
{
    public async Task<IEnumerable<TextBookType>> ExecuteAsync()
    {
        return await textBookTypesRepository.GetTextBookTypes();
    }

    public async Task<TextBookType> ExecuteAsync(int id)
    {
        return await textBookTypesRepository.GetTextBookTypeById(id);
    }
    
}