using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class ContractsEFCoreRepository(IDbContextFactory<JedsterContext> _factory) : IContractRepository
{
    public async Task DeleteContractAsync(int contractId)
    {
        await using var db = _factory.CreateDbContext();
        var contract = await db.Contracts.FindAsync(contractId);
        if (contract != null)
        {
            db.Contracts.Remove(contract);
            await db.SaveChangesAsync();
        }
    }

    public async Task EditContractAsync(Contract contract)
    {
        await using var db = _factory.CreateDbContext();
        var existingContract = await db.Contracts.FindAsync(contract.ContractId);
        if (existingContract != null)
        {
            existingContract.SetHoursRemaning(contract.GetHoursRemaining());
            await db.SaveChangesAsync();
        }
    }

    public async Task<Contract> GetContractByIdAsync(int contractId)
    {
        await using var db = _factory.CreateDbContext();
        return await db.Contracts.FindAsync(contractId) ?? null;
    }

    public async Task<IEnumerable<Contract>> GetContractsAsync()
    {
        await using var db = _factory.CreateDbContext();
        return await db.Contracts?.ToListAsync() ?? null;
    }

    public async Task AddContractAsync(IContractRepository contractRepository)
    {
        throw new NotImplementedException();
    }
}