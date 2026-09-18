using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;

namespace Jedster.Plugins.InMemory;

public class LessonRepository : ILessonsRepository
{
    private readonly List<Lesson> _lessons = [];

    public Task<Lesson> UpdateLessonAsync(Lesson lesson)
    {
        if (lesson is null) return Task.FromResult<Lesson>(null!);

        var index = _lessons.FindIndex(l => l.LessonId == lesson.LessonId);
        if (index >= 0)
        {
            _lessons[index] = lesson;
        }

        return Task.FromResult(lesson);
    }

    public Task<IEnumerable<Lesson>> GetLessonsAsync()
    {
        return Task.FromResult<IEnumerable<Lesson>>(_lessons);
    }

    public Task<bool> LessonExistsAsync(int groupId, DateTime date)
    {
        return Task.FromResult(_lessons.Any(l => l.GroupId == groupId && l.StartTime == date));
    }

    public Task<Lesson> AddLessonAsync(Lesson lesson)
    {
        var nextId = _lessons.Count > 0 ? _lessons.Max(l => l.LessonId) + 1 : 1;
        lesson.LessonId = nextId;
        _lessons.Add(lesson);
        return Task.FromResult(lesson);
    }
}