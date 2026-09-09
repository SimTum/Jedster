using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Lessons;

public class LessonExistsUseCase(ILessonsRepository lessonsRepository) : ILessonExistsUseCase
{
    public async Task<bool> ExecuteAsync(int groupId, DateTime date)
    {
        return await lessonsRepository.LessonExistsAsync(groupId, date);
    }
}