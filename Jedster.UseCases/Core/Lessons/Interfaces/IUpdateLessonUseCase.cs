using Jedster.CoreBusiness;

namespace Jedster.UseCases.Lessons;

public interface IUpdateLessonUseCase
{
    Task<Lesson> ExecuteAsync(Lesson lesson);
}