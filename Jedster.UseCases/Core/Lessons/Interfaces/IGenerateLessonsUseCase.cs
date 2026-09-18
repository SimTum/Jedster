using Jedster.CoreBusiness;

namespace Jedster.UseCases.Lessons;

public interface IGenerateLessonsUseCase
{
    Task ExecuteAsync(DateTime? from = null, int days = 30);
}