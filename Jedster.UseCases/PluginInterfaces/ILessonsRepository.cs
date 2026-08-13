using Jedster.CoreBusiness;

namespace Jedster.UseCases.PluginInterfaces;

public interface ILessonsRepository
{
    Task<Lesson> UpdateLessonAsync(Lesson lesson);
    Task<IEnumerable<Lesson>> GetLessonsAsync();
    Task<IEnumerable<Lesson>> GenerateLessonsAsync();
}