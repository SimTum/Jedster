using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Core.Contracts;

public class EditContractUseCase(IContractRepository contractRepository) : IEditContractUseCase
{
    public async Task ExecuteAsync(Contract contract)
    {
        await contractRepository.EditContractAsync(contract);
    }
}