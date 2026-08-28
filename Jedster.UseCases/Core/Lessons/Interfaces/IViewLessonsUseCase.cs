using Jedster.CoreBusiness;

namespace Jedster.UseCases.Lessons;

public interface IViewLessonsUseCase
{
    Task<IEnumerable<Lesson>> ExecuteAsync();
}