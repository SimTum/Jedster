using Jedster.CoreBusiness;

namespace Jedster.UseCases.Groups;

public interface IEditGroupUseCase
{
    Task ExecuteAsync(Group group);
}