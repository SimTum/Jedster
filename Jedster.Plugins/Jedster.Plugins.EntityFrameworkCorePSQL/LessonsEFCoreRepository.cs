using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class LessonsEFCoreRepository : ILessonsRepository
{
    public async Task<Lesson> UpdateLessonAsync(Lesson lesson)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Lesson>> GetLessonsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> LessonExistsAsync(int groupId, DateTime date)
    {
        throw new NotImplementedException();
    }

    public async Task<Lesson> AddLessonAsync(Lesson lesson)
    {
        throw new NotImplementedException();
    }
}