using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class LessonsEfCoreRepository(IDbContextFactory<JedsterContext> _factory) : ILessonsRepository
{
    public async Task<Lesson> UpdateLessonAsync(Lesson lesson)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var existing = await db.Lessons.FindAsync(lesson.LessonId);
        if (existing != null)
        {
            existing.Status = lesson.Status;
            existing.IsPaid = lesson.IsPaid;
            existing.StartTime = lesson.StartTime;
            existing.EndTime = lesson.EndTime;
            existing.Duration = lesson.Duration;
            if (lesson.GroupId > 0) existing.GroupId = lesson.GroupId;
            if (lesson.TeacherId > 0) existing.TeacherId = lesson.TeacherId;
            await db.SaveChangesAsync();
            return existing;
        }
        return lesson;
    }

    public async Task<IEnumerable<Lesson>> GetLessonsAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Lessons
            .Include(l => l.Group)
            .Include(l => l.Teacher)
            .Include(l => l.Students)
            .Include(l => l.Attendances!)
                .ThenInclude(a => a.Student)
            .ToListAsync();
    }

    public async Task<bool> LessonExistsAsync(int groupId, DateTime date)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Lessons.AnyAsync(l => l.GroupId == groupId && l.StartTime == date);
    }

    public async Task AddLessonAsync(Lesson lesson)
    {
        await using var db = await _factory.CreateDbContextAsync();

        var students = lesson.Students?.ToList();
        lesson.Group = null;
        lesson.Teacher = null;
        lesson.Attendances = null;
        lesson.Students = null;

        db.Lessons.Add(lesson);
        await db.SaveChangesAsync();

        if (students != null && students.Count > 0)
        {
            var studentIds = students.Select(s => s.StudentId).ToList();
            var dbStudents = await db.Students.Where(s => studentIds.Contains(s.StudentId)).ToListAsync();
            lesson.Students = dbStudents;
            await db.SaveChangesAsync();
        }
    }
}