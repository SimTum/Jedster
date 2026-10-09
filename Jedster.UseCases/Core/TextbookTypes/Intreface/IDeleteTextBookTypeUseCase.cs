namespace Jedster.UseCases.Core.TextbookTypes;

public interface IDeleteTextBookTypeUseCase
{
    Task ExecuteAsync(int id);
}