using Jedster.CoreBusiness;

namespace Jedster.UseCases.PluginInterfaces;

public interface IMaterialRepository
{
    Task<IEnumerable<Textbook>> GetMaterialsByNameAsync(string materialName);
    Task<Textbook> GetMateiralByIdAsync(int materialId);
    Task RegisterMaterialAsync(Textbook material);
    Task EditMaterialAsync(Textbook material);
    Task DeleteMaterialByIdAsync(int materialId);
}