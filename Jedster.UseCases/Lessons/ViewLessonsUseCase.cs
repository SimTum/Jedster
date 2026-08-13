using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.UseCases.Lessons;

public class ViewLessonsUseCase(ILessonsRepository lessonsRepository) : IViewLessonsUseCase
{
    public async Task<IEnumerable<Lesson>> ExecuteAsync()
    {
        return await lessonsRepository.GetLessonsAsync();
    }
}