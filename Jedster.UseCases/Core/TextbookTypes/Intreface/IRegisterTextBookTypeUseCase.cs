using Jedster.CoreBuisness;

namespace Jedster.UseCases.Core.TextbookTypes;

public interface IRegisterTextBookTypeUseCase
{
    Task ExecuteAsync(TextBookType textBookType);
}