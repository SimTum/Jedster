using Jedster.CoreBusiness;

namespace Jedster.UseCases.PluginInterfaces;

public interface IContractRepository
{
    Task DeleteContractAsync(int contractId);
    Task EditContractAsync(Contract contract);
    Task<Contract> GetContractByIdAsync(int contractId);
    Task<IEnumerable<Contract>> GetContractsAsync();
    Task AddContractAsync(IContractRepository contractRepository);
}