using Jedster.CoreBusiness;

namespace Jedster.UseCases.Materials;

public interface IViewMaterialUseCase
{
    Task<IEnumerable<Textbook>> ExecuteAsync(string materialName = " ");
    Task<Textbook> ExecuteAsync(int materialId);
}