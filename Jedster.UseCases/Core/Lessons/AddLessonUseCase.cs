using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Lessons;

public class AddLessonUseCase(ILessonsRepository lessonRepository)
{
    public async Task<Lesson> ExecuteAsync(Lesson lesson)
    {
        return await lessonRepository.AddLessonAsync(lesson);
    }
}