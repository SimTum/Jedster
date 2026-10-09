using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Core.Contracts;

public class ViewContractUseCase(IContractRepository contractRepository) : IViewContractUseCase
{
    public async Task<IEnumerable<Contract>> ExecuteAsync()
    {
        return await contractRepository.GetContractsAsync();
    }
    public async Task<Contract> ExecuteAsync(int contractId) 
    {
        return await contractRepository.GetContractByIdAsync(contractId);
    }
}