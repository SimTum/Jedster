namespace Jedster.UseCases.Materials;

public interface IDeleteMaterialUseCase
{
    Task ExecuteAsync(int materialId);
}