using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Core.Contracts;

public class DeleteContractUseCase(IContractRepository contractRepository) : IDeleteContractUseCase
{
    public async Task ExecuteAsync(int contractId)
    {
        await contractRepository.DeleteContractAsync(contractId);
    }
}