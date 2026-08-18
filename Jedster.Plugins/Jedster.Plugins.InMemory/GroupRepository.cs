using System;
using System.Text.RegularExpressions;
using Jedster.UseCases.PluginInterfaces;
using Jedster.CoreBusiness;
using Group = Jedster.CoreBusiness.Group;

namespace Jedster.Plugins.InMemory;

public class GroupRepository : IGroupRepository
{
    private List<Group> _groups;

    public GroupRepository()
    {
        _groups = new List<Group>
        {
            new Group
            {
                GroupId = 1, NumberStudents = 3, Name = "Kids1", WeekDay = "SEG", StartTime = new TimeOnly(17, 30),
                EndTime = new TimeOnly(19, 30), TeacherId = 1
            },
            new Group
            {
                GroupId = 2, NumberStudents = 2
, Name = "Kids2", WeekDay = "SEG", StartTime = new TimeOnly(19, 30),
                EndTime = new TimeOnly(21, 30), TeacherId = 1
            },
            new Group
            {
                GroupId = 3, NumberStudents = 5, Name = "Teens1", WeekDay = "QUA", StartTime = new TimeOnly(14, 30),
                EndTime = new TimeOnly(16, 30), TeacherId = 2
            },
            new Group
            {
                GroupId = 4, NumberStudents = 3, Name = "Adults1", WeekDay = "SEG", StartTime = new TimeOnly(17, 30),
                EndTime = new TimeOnly(19, 30), TeacherId = 1
            },
            new Group
            {
                GroupId = 5, NumberStudents = 3, Name = "Kids3", WeekDay = "SEG", StartTime = new TimeOnly(17, 30),
                EndTime = new TimeOnly(19, 30), TeacherId = 1
            },
            new Group
            {
                GroupId = 6, NumberStudents = 3, Name = "Adults2", WeekDay = "SEG", StartTime = new TimeOnly(17, 30),
                EndTime = new TimeOnly(19, 30), TeacherId = 4
            },
            new Group
            {
                GroupId = 7, NumberStudents = 2, Name = "Teens2", WeekDay = "SEG", StartTime = new TimeOnly(17, 30),
                EndTime = new TimeOnly(19, 30), TeacherId = 3
            }
        };
    }

    public List<Group> GetGroups()
    {
        return _groups;
    }

    public async Task<IEnumerable<Group>> GetGroupsByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_groups);

        return _groups.Where(x => x.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<Group?> GetGroupByIdAsync(int groupId)
    {
        if (_groups.Any(x => x.GroupId == groupId))
        {
            return await Task.FromResult(_groups.FirstOrDefault(x => x.GroupId == groupId));
        }
        else
        {
            return null;
        }
    }

    public Task RegisterGroup(Group group)
    {
        if (_groups.Any(x => x.Name.Equals(group.Name, StringComparison.OrdinalIgnoreCase)))
        {
            return Task.CompletedTask;
        }

        var maxId = _groups.Max(x => x.GroupId);
        group.GroupId = maxId + 1;

        _groups.Add(group);
        return Task.CompletedTask;
    }


    public Task EditGroupAsync(Group group)
    {
        if (_groups.Any(x =>
                x.Name.Equals(group.Name, StringComparison.OrdinalIgnoreCase) && x.GroupId != group.GroupId))
            return Task.CompletedTask;

        var groupToUpdate = _groups.FirstOrDefault(x => x.GroupId == group.GroupId);
        if (groupToUpdate is not null)
        {
            groupToUpdate.Name = group.Name;
            groupToUpdate.StartTime = group.StartTime;
            groupToUpdate.EndTime = group.EndTime;
            groupToUpdate.TeacherId = group.TeacherId;
            groupToUpdate.Teacher = group.Teacher;
            groupToUpdate.WeekDay = group.WeekDay;
        }

        return Task.CompletedTask;
    }

    public Task DeleteGroupByIdAsync(int groupId)
    {
        var groupToDelete = _groups.FirstOrDefault(x => x.GroupId == groupId);
        if (groupToDelete is not null)
        {
            _groups.Remove(groupToDelete);
        }

        return Task.CompletedTask;
    }
}