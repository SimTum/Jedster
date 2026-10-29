using Jedster.CoreBusiness;

namespace Jedster.UseCases.Core.TextbookTypes;

public interface IEditTextBookTypeUseCase
{
    Task ExecuteAsync(TextBookType textBookType);
}