using Jedster.CoreBusiness;

namespace Jedster.UseCases.Core.Contracts.Interfaces;

public interface IAddContractUseCase
{
    Task ExecuteAsync(Contract contract);
}