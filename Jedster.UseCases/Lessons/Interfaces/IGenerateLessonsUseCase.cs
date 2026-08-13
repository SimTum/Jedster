using Jedster.CoreBusiness;

namespace Jedster.UseCases.Lessons;

public interface IGenerateLessonsUseCase
{
    Task<IEnumerable<Lesson>> ExecuteAsync();
}