using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Lessons;

public class UpdateLessonUseCase(ILessonsRepository lessonsRepository) : IUpdateLessonUseCase 
{
    public async Task<Lesson> ExecuteAsync(Lesson lesson)
    {
        return await lessonsRepository.UpdateLessonAsync(lesson);
    }
}