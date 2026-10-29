using Jedster.CoreBusiness;

namespace Jedster.UseCases.Core.TextbookTypes;

public interface IViewTextbookTypesUseCase
{
    Task<IEnumerable<TextBookType>> ExecuteAsync();
    Task<TextBookType> ExecuteAsync(int id);
}