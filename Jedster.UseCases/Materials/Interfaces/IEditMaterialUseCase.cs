using Jedster.CoreBusiness;

namespace Jedster.UseCases.Materials;

public interface IEditMaterialUseCase
{
    Task ExecuteAsync(Material material);
}