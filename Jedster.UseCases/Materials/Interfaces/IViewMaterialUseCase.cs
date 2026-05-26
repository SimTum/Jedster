using Jedster.CoreBusiness;

namespace Jedster.UseCases.Materials;

public interface IViewMaterialUseCase
{
    Task<IEnumerable<Material>> ExecuteAsync(string materialName = " ");
    Task<Material> ExecuteAsync(int materialId);
}