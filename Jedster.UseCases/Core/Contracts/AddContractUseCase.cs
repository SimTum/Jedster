using Jedster.CoreBusiness;
using Jedster.UseCases.Core.Contracts.Interfaces;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Core.Contracts;

public class AddContractUseCase(IContractRepository contractRepository) : IAddContractUseCase
{
    public async Task ExecuteAsync(Contract contract)
    {
        await contractRepository.AddContractAsync(contractRepository);
    }
}