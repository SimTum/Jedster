using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Lessons;

public class AddLessonUseCase(ILessonsRepository lessonRepository)
{
    public async Task ExecuteAsync(Lesson lesson)
    {
        await lessonRepository.AddLessonAsync(lesson);
    }
}