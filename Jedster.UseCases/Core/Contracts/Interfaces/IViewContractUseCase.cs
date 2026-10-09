using Jedster.CoreBusiness;

namespace Jedster.UseCases.Core.Contracts;

public interface IViewContractUseCase
{
    Task<IEnumerable<Contract>> ExecuteAsync();
    Task<Contract> ExecuteAsync(int contractId);
}