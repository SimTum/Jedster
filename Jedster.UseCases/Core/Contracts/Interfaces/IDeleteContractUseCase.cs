namespace Jedster.UseCases.Core.Contracts;

public interface IDeleteContractUseCase
{
    Task ExecuteAsync(int contractId);
}