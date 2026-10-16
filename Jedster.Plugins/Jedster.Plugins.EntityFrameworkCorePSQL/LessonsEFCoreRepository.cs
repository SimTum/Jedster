using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class LessonsEfCoreRepository(IDbContextFactory<JedsterContext> _factory) : ILessonsRepository
{
    public async Task<Lesson> UpdateLessonAsync(Lesson lesson)
    {
        await using var db =  await _factory.CreateDbContextAsync();
        db.Lessons.Update(lesson);
        await db.SaveChangesAsync();
        return lesson;
    }

    public async Task<IEnumerable<Lesson>> GetLessonsAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Lessons.ToListAsync();
    }

    public async Task<bool> LessonExistsAsync(int groupId, DateTime date)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Lessons.AnyAsync(l => l.GroupId == groupId && l.StartTime == date);
    }

    public async Task AddLessonAsync(Lesson lesson)
    {
        await using var db = await _factory.CreateDbContextAsync();
        db.Lessons.Add(lesson);
        await db.SaveChangesAsync();
    }
}