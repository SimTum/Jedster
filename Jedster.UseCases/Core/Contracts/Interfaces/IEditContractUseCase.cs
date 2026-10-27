using Jedster.CoreBusiness;

namespace Jedster.UseCases.Core.Contracts.Interfaces;

public interface IEditContractUseCase
{
    Task ExecuteAsync(Contract contract);
}