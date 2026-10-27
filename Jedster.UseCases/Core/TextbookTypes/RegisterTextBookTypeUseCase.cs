using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Core.TextbookTypes;

public class RegisterTextBookTypeUseCase(ITextBookTypesRepository textBookTypesRepository) : IRegisterTextBookTypeUseCase
{
    public async Task ExecuteAsync(TextBookType textBookType)
    {
        await textBookTypesRepository.RegisterTextBookType(textBookType);
    }
}