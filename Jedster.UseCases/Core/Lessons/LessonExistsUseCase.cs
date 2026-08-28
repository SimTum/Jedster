using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Lessons;

public class LessonExistsUseCase(ILessonsRepository lessonsRepository) : ILessonExistsUseCase
{
    public async Task<bool> ExecuteAsync(int lessonId)
    {
        return await lessonsRepository.LessonExistsAsync(lessonId);
    }
}