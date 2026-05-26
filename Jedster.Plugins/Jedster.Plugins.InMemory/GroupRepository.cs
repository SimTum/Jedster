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
        _groups = new List<Group> {
            new Group
            {
                GroupId = 1, NumberStudents = 3, Name = "Kids1" ,WeekDay = "SEG", StartTime = new TimeOnly(17,30), EndTime = new TimeOnly (19,30), TeacherId = 1
            },
            new Group
            {
                GroupId = 2, NumberStudents = 4, Name = "Kids2" ,WeekDay = "SEG", StartTime = new TimeOnly(19,30), EndTime = new TimeOnly (21,30), TeacherId = 1
            },
            new Group
            {
                GroupId = 3, NumberStudents = 5, Name = "Teens1" ,WeekDay = "QUA", StartTime = new TimeOnly(14,30), EndTime = new TimeOnly (16,30), TeacherId = 2
            },
            new Group
            {
                GroupId = 4, NumberStudents = 3, Name = "Adults1" ,WeekDay = "SEG", StartTime = new TimeOnly(17,30), EndTime = new TimeOnly (19,30), TeacherId = 1
            },
        };
    }

    public Task<IEnumerable<Group>> GetGroupsByNameAsync(string nome)
    {
        throw new NotImplementedException();
    }

    public Task RegisterGroup(Group group)
    {
        throw new NotImplementedException();
    }

    public Task<Group?> GetGroupByIdAsync(int groupId)
    {
        throw new NotImplementedException();
    }

    public Task EditGroupAsync(Group group)
    {
        throw new NotImplementedException();
    }

    public Task DeleteGroupByIdAsync(int groupId)
    {
        throw new NotImplementedException();
    }

    public Task RegisterGroup(System.Text.RegularExpressions.Group group)
    {
        throw new NotImplementedException();
    }

    Task<IEnumerable<Group>> IGroupRepository.GetGroupsByNameAsync(string nome)
    {
        throw new NotImplementedException();
    }
}
