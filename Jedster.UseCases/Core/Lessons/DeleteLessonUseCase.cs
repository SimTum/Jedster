using Jedster.CoreBuisness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Lessons;

public class DeleteLessonUseCase (ILessonsRepository lessonRepository) : IDeleteLessonUseCase
{
    public async Task ExecuteAsync(int id)
    {
        await lessonRepository.DeleteLessonAsync(id);
    }
}