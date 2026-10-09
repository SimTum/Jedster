using Jedster.CoreBusiness;

namespace Jedster.UseCases.Core.Contracts;

public interface IAddContractUseCase
{
    Task ExecuteAsync(Contract contract);
}