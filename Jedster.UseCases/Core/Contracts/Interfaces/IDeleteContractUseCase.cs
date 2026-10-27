namespace Jedster.UseCases.Core.Contracts.Interfaces;

public interface IDeleteContractUseCase
{
    Task ExecuteAsync(int contractId);
}