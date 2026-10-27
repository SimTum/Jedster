using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Core.TextbookTypes;

public class EditTextBookTypeUseCase(ITextBookTypesRepository textBookTypesRepository) : IEditTextBookTypeUseCase
{
    public async Task ExecuteAsync(TextBookType textBookType)
    {
        await textBookTypesRepository.UpdateTextBookType(textBookType);
    }
    
}