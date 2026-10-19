using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class ContractsEfCoreRepository(IDbContextFactory<JedsterContext> _factory) : IContractRepository
{
    public async Task DeleteContractAsync(int contractId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var contract = await db.Contracts.FindAsync(contractId);
        if (contract != null)
        {
            db.Contracts.Remove(contract);
            await db.SaveChangesAsync();
        }
    }

    public async Task EditContractAsync(Contract contract)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var existingContract = await db.Contracts.FindAsync(contract.ContractId);
        if (existingContract != null)
        {
            existingContract.SetHoursRemaning(contract.GetHoursRemaining());
            await db.SaveChangesAsync();
        }
    }

    public async Task<Contract> GetContractByIdAsync(int contractId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Contracts.FindAsync(contractId) ?? null;
    }

    public async Task<IEnumerable<Contract>> GetContractsAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Contracts.Include(c => c.Student).ToListAsync();
    }

    public async Task AddContractAsync(Contract contract)
    {
        await using var db = await _factory.CreateDbContextAsync();
        if (db.Contracts != null)
        {
            db.Contracts.Add(contract);
            await db.SaveChangesAsync();
        }
    }
}