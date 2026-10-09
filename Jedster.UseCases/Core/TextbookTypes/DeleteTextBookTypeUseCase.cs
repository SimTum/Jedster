using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Core.TextbookTypes;

public class DeleteTextBookTypeUseCase(ITextBookTypesRepository textBookTypesRepository) : IDeleteTextBookTypeUseCase
{
    public async Task ExecuteAsync(int id)
    {
        await textBookTypesRepository.DeleteTextBookType(id);
    }
    
}