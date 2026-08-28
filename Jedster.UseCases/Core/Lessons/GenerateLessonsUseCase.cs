using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Lessons;

public class GenerateLessonsUseCase (ILessonsRepository lessonsRepository) : IGenerateLessonsUseCase
{
    public async Task<IEnumerable<Lesson>> ExecuteAsync()
    {
        return await lessonsRepository.GenerateLessonsAsync();
    }
}