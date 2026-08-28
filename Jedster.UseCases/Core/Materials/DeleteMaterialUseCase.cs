using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Materials;

public class DeleteMaterialUseCase(IMaterialRepository materialRepository) : IDeleteMaterialUseCase
{
    public async Task ExecuteAsync(int materialId)
    {
        await materialRepository.DeleteMaterialByIdAsync(materialId);
    }
}