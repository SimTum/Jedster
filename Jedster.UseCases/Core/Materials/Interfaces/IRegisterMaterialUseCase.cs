using Jedster.CoreBusiness;

namespace Jedster.UseCases.Materials;

public interface IRegisterMaterialUseCase
{
    Task ExecuteAsync(Textbook material);
}