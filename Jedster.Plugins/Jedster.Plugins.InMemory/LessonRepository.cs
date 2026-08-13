using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.Plugins.InMemory;

public class LessonRepository : ILessonsRepository
{
    public Task<Lesson> UpdateLessonAsync(Lesson lesson)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Lesson>> GetLessonsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Lesson>> GenerateLessonsAsync()
    {
        throw new NotImplementedException();
    }
}