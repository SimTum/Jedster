using Jedster.CoreBusiness;
using Jedster.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Jedster.Plugins.EntityFrameworkCorePSQL;

public class GroupsEfCoreRepository(IDbContextFactory<JedsterContext> _factory) : IGroupRepository
{
    public async Task<IEnumerable<Group>> GetGroupsByNameAsync(string nome)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Groups?.Include(g => g.Teacher).ToListAsync()!;
    }

    public async Task RegisterGroup(Group group)
    {
        await using var db = await _factory.CreateDbContextAsync();
        if (db.Groups != null)
        {
            db.Groups.Add(group);
            // group.UpdateTeacherHours();
        }
        await db.SaveChangesAsync();
    }

    public async Task<Group?> GetGroupByIdAsync(int groupId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        return await db.Groups.FindAsync(groupId) ?? null;
    }

    public async Task EditGroupAsync(Group group)
    {
        await using var db = await _factory.CreateDbContextAsync();
        var _group = await db.Groups.FindAsync(group.GroupId);
        if (_group != null)
        {
            
            // _group = group;
            _group.Name = group.Name;
            _group.StartTime = group.StartTime;
            _group.EndTime = group.EndTime;
            _group.TeacherId = group.TeacherId;
            _group.WeekDay = group.WeekDay;
            _group.NumberStudents = group.NumberStudents;

            await db.SaveChangesAsync();

        }
    }

    public async Task DeleteGroupByIdAsync(int groupId)
    {
        await using var db = await _factory.CreateDbContextAsync();
        db.Groups?.Remove(await db.Groups.FindAsync(groupId) ?? throw new InvalidOperationException());
        await db.SaveChangesAsync();
        ;
    }
}