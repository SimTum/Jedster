using Jedster.CoreBusiness;

namespace Jedster.UseCases.Core.Contracts;

public interface IEditContractUseCase
{
    Task ExecuteAsync(Contract contract);
}