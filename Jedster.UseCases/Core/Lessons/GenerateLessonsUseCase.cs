using Jedster.UseCases.Core.Scheduling;

namespace Jedster.UseCases.Lessons;

public class GenerateLessonsUseCase(GenerateLessonsAndAttendace generateLessonsAndAttendace) : IGenerateLessonsUseCase
{
    public async Task ExecuteAsync(DateTime? from = null, int days = 30)
    {
        await generateLessonsAndAttendace.ExecuteAsync(from, days);
    }
}