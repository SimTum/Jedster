using Jedster.CoreBusiness;

namespace Jedster.UseCases.Groups;

public interface IRegisterGroupUseCase
{
    Task ExecuteAsync(Group group);
}