using Jedster.CoreBusiness;

namespace Jedster.UseCases.Groups;

public interface IViewGroupUseCase
{
    Task<IEnumerable<Group>> ExecuteAsync(string groupName);
    Task<Group?> ExecuteAsync(int groupId);
}